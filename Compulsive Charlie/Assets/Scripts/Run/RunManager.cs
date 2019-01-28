using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

// Script managing all the state and gameplay of a single run
public class RunManager : MonoBehaviour
{
    public GameManager gameManager;
    public RunState runState;
    public PlayerController player;
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
        // get initial runState based on profile
        runState = new RunState(
            gameManager.profile.initialMoney,
            gameManager.profile.initialEnergy, 
            new EmotionState(gameManager.profile.emotionEquilibriums)
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
        if (runState.money <= 0)
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
            // increment timeSteps
            runState.timeSteps += 1;
            // update activity and money histories
            runState.activityHistory.Add(newActivityPlatform);
            runState.moneyHistory.Add(runState.money);
            runState.height = newActivityPlatform.y;
            // clear out other spawnedPlatforms
            runState.ClearSpawned(newActivityPlatform);
            // start new platform spawning rhythm notes - deactivate this
            // newActivityPlatform.StartRhythm();
        }

        // offer thoughts
        // thoughtMenu.Activate(SelectThoughts());

        // return zoom to normal
        camera.ZoomNormal();
    }

    // for when the player enters the jump Pad
    public void EnterJumpPad(ActivityPlatform activityPlatform)
    {
        // spawn new set of platforms
        foreach (Activity activity in SelectActivities())
        {
            SpawnPlatform(activity);
        }

        // Zoom out for jump
        // TODO: dynamic zoom w/ parameter depening on platform heights
        camera.ZoomOut();

        if (activityPlatform != null)
        {
            // stop platform spawning rhythm notes
            if (runState.CurrentActivityPlatform())
            {
                runState.CurrentActivityPlatform().StopRhythm();
            }
        }

        // regenerate energy
        runState.IncreaseEnergy(gameManager.profile.energyRegen);

        // gradually increase craving based on emotion intensity
        runState.IncreaseCraving(runState.emotions.CravingIncrease());

        // cap energy
        runState.energy = System.Math.Min(runState.energy, gameManager.profile.energyCap);

        // offer thoughts
        thoughtMenu.Activate(SelectThoughts());
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
        // TODO: tinker with this scheme (right now it sort of randomly picks activities one at a time)
        availableActivities = availableActivities.OrderBy(x => Random.value).ToList();
        foreach (Activity available in availableActivities)
        {
            // don't offer activities that are too crammed together
            bool crammed = false;
            foreach (Activity offered in offeredActivities)
            {
                if (System.Math.Abs(offered.PlatformHeight(runState) - available.PlatformHeight(runState)) < 2)
                {
                    crammed = true;
                }
            }
            if (!crammed)
            {
                offeredActivities.Add(available);
            }
        }
        // There's got to be at least one activity lower than current!
        if (true) // (offeredActivities.Where(a => a.HeightRating(runState) < 0).ToList().Count == 0)
        {
            // right now it's called "Do Nothing"
            Activity fallBack = Object.FindObjectOfType<DoNothing>(); ;
            offeredActivities.Add(fallBack);
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
            Thought fallBack = Object.FindObjectOfType<Nothing>(); ;
            return new List<Thought> { fallBack };
        }
        // select <=3 randomly (with repeat)
        List<Thought> offeredThoughts = new List<Thought>();
        for (int i=0; i < 3; i++)
        {
            int r = Random.Range(0, availableThoughts.Count);
            offeredThoughts.Add(availableThoughts[r]);
        }
        return offeredThoughts;
    }
}
