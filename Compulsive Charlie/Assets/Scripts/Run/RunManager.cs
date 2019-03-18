using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

// Script managing all the state and gameplay of a single run
public class RunManager : MonoBehaviour
{
    public const int minPlatformHeightDiff = 3;

    public GameManager gameManager;
    public RunState runState;
    public PlayerController player;
    public RhythmManager rhythmManager;
    public new CameraController camera;
    public ThoughtMenu thoughtMenu;

    // prefabs
    public GameObject platformPrefab;

    // Initialization
    void Awake()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        // if no gameManager, load preload scene first
        if (gameManager == null)
        {
            SceneManager.LoadScene(0);
            return;
        }
        // get reference to playerController and rhythmManager
        player = Object.FindObjectOfType<PlayerController>();
        rhythmManager = Object.FindObjectOfType<RhythmManager>();
        // get initial runState based on profile
        runState = new RunState(
            gameManager.profile.initialEnergy,
            gameManager.profile.energyCap,
            new EmotionState(gameManager.profile.initialEmotions)
        );
        thoughtMenu.Initialize();
    }

    private void Update()
    {
        // [fail-check] if fallen way down, end run and advance scenes
        if (player.transform.position.y < -100)
        {
            gameManager.EndRun(runState);
        }
        // if broke, end run (and skip the rest of the procedure)
        if (runState.done)
        {
            gameManager.EndRun(runState);
            return;
        }
    }

    // for when the player arrives on next activity, called via trigger in ActivityPlatform
    public void AdvanceTimeStep(ActivityPlatform newActivityPlatform)
    {
        if (newActivityPlatform != null)
        {
            if (runState.activityHistory.Count == 0 && newActivityPlatform.activity == null)
            {
                newActivityPlatform.activity = Object.FindObjectOfType<SleepIn>();
            }
            // increment timeSteps
            runState.timeSteps += 1;
            // update activity history
            runState.activityHistory.Add(newActivityPlatform);
            runState.height = newActivityPlatform.y;
            // clear out other spawnedPlatforms
            runState.ClearSpawned(newActivityPlatform);
            // start new platform spawning rhythm notes - deactivate this
            rhythmManager.StartRhythm(newActivityPlatform.activity);

            // start activity animation
            Debug.Log(newActivityPlatform.activity.name + " hash:" + Animator.StringToHash(newActivityPlatform.activity.name));
            player.GetComponent<Animator>().SetInteger("activityHash", Animator.StringToHash(newActivityPlatform.activity.name));
            player.GetComponent<Animator>().SetTrigger("startActivity");

            // trigger activity special effect
            runState.CurrentActivityPlatform().activity.Effect(runState);
        }

        // offer thoughts
        // thoughtMenu.Activate(SelectThoughts());

        // return zoom to normal
        camera.ZoomNormal();
    }

    // for when the player enters the jump Pad
    public void EnterJumpPad(ActivityPlatform activityPlatform)
    {
        // gameManager.EndRun(runState); //test
        // end activity animation
        player.GetComponent<Animator>().SetTrigger("finishActivity");

        // Zoom out for jump
        camera.ZoomOut();

        if (activityPlatform != null)
        {
            // stop rhythm game
            if (runState.CurrentActivityPlatform())
            {
                rhythmManager.StopRhythm();
            }
        }

        // regenerate energy
        runState.IncreaseEnergy(gameManager.profile.energyRegen);

        // cap energy
        runState.energy = System.Math.Min(runState.energy, gameManager.profile.energyCap);

        // spawn new set of platforms
        foreach (Activity activity in SelectActivities())
        {
            SpawnPlatform(activity);
        }
    }

    // called from player controller after sensing ready to jump
    // may be called again from thought menu if wanting to offer thoughts again
    public void PreJump()
    {
        // offer thoughts
        thoughtMenu.Activate(SelectThoughts());
    }

    // called from thought menu after selecting a thought
    public void PostThoughtSelect()
    {
        // refill available platforms in case any were deleted
        foreach (Activity activity in SelectActivities())
        {
            SpawnPlatform(activity);
        }
        player.Jump();
    }

    // instantiate a new activity platform
    private void SpawnPlatform(Activity activity)
    {
        GameObject platform = Instantiate(platformPrefab);
        platform.GetComponent<ActivityPlatform>().Initialize(activity);
        // add it to list of prospective platforms in runState
        runState.spawnedPlatforms.Add(platform.GetComponent<ActivityPlatform>());
    }

    // select activities from pool of available
    private List<Activity> SelectActivities()
    {      
        List<Activity> offeredActivities = new List<Activity>();
        // get all available activities
        List<Activity> availableActivities = new List<Activity>();
        foreach (Activity activity in gameManager.profile.activities)
        {
            for (int i = 0; i < activity.Availability(runState); i++)
            {
                availableActivities.Add(activity);
            }
        }
        // Randomly pick activities one at a time
        availableActivities = availableActivities.OrderBy(x => Random.value).ToList();
        // Put scheduled activity at front of list so it is always offered
        Activity scheduledActivity = gameManager.profile.GetSchedule(runState.timeSteps);
        availableActivities.Insert(0, scheduledActivity);
        foreach (Activity available in availableActivities)
        {
            // don't offer activities that are too crammed together
            bool crammed = false;
            foreach (Activity offered in offeredActivities.Concat(runState.spawnedPlatforms.Select(x => x.activity)))
            {
                int h1 = offered.HeightRating(runState);
                int h2 = available.HeightRating(runState);
                if (System.Math.Abs(h1 - h2) < minPlatformHeightDiff)
                {
                    crammed = true;
                }
                // dont add activities that are above the scheduled one
                if (h2 - scheduledActivity.HeightRating(runState) > 0)
                {
                    crammed = true;
                }
            }
            if (!crammed)
            {
                offeredActivities.Add(available);
            }
        }
        // There's got to be at least one default activity
        List<Activity> allActivities = offeredActivities.Concat(runState.spawnedPlatforms.Select(x => x.activity)).ToList();
        if (allActivities.Where(a => a.HeightRating(runState) == Activity.defaultPlatformHeightDiff).ToList().Count == 0)
        {
            Activity defaultActivity = availableActivities.Find(a => a.HeightRating(runState) == Activity.defaultPlatformHeightDiff);
            if (defaultActivity != null)
            {
                offeredActivities.Add(defaultActivity);
            } else
            {
                // right now default to "Do Nothing"
                Activity fallBack = Object.FindObjectOfType<DoNothing>();
                offeredActivities.Add(fallBack);
            }
        }
        return offeredActivities;
    }

    // select thoughts from pool of available
    private List<Thought> SelectThoughts()
    {
        // get all available thoughts
        List<Thought> availableThoughts = new List<Thought>();
        foreach (Thought thought in gameManager.profile.thoughts)
        {
            for (int i=0; i < thought.Availability(runState); i++)
            {
                availableThoughts.Add(thought);
            }
        }
        // associated thoughts are extra likely - TODO: tune, maybe use different scheme?
        if (runState.CurrentActivity())
        {
            foreach (Thought thought in runState.CurrentActivity().associatedThoughts)
            {
                for (int i = 0; i < thought.Availability(runState); i++)
                {
                    availableThoughts.Add(thought);
                }
            }
        }
            
        // if none available, return special filler thought
        if (availableThoughts.Count == 0)
        {
            // right now it's called "Nothing"
            Thought fallBack = Object.FindObjectOfType<Nothing>();
            return new List<Thought> { fallBack };
        }
        // select <=3 randomly (without repeat)
        List<Thought> offeredThoughts = new List<Thought>();
        while (offeredThoughts.Count < 3 && availableThoughts.Count > 0)
        {
            int r = Random.Range(0, availableThoughts.Count);
            Thought t = availableThoughts[r];
            availableThoughts.Remove(t);
            offeredThoughts.Add(t);
        }
        return offeredThoughts;
    }
}
