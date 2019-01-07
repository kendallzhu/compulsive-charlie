using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        // get initial runState (TODO: based on profile)
        runState = new RunState(12, new EmotionState());
        thoughtMenu.Initialize();
    }

    private void Update()
    {
        // [fail-check] if fallen way down, end run and advance scenes
        if (player.transform.position.y < -100)
        {
            gameManager.EndRun(int.MinValue);
        }
    }

    // for when the player arrives on next activity, called via trigger in ActivityPlatform
    public void AdvanceTimeStep(ActivityPlatform newActivityPlatform)
    {
        if (newActivityPlatform != null)
        {
            // increment timeSteps
            runState.timeSteps += 1;
            // update activity and score histories
            runState.activityHistory.Add(newActivityPlatform);
            runState.scoreHistory.Add(newActivityPlatform.y);
            // if time limit exceeded, end run (and skip the rest of the procedure)
            if (runState.timeSteps > gameManager.profile.timeLimit)
            {
                gameManager.EndRun(runState.CurrentScore());
                return;
            }
            // clear out other spawnedPlatforms
            runState.ClearSpawned(newActivityPlatform);
            // start new platform spawning rhythm notes
            newActivityPlatform.StartRhythm();
        }

        // offer thoughts
        thoughtMenu.Activate(SelectThoughts());

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
        runState.energy += gameManager.profile.energyRegen;
        // drain energy when emotions are strong (was gonna do for high score too but thinking nah)
        // Debug.Log(runState.emotions.EnergyDrain());
        runState.energy -= runState.emotions.EnergyDrain();

        // gradually bring emotion axes back to equilibrium levels
        // (TODO: certain activities can do this more strongly like sleep)
        runState.emotions.Equilibrate(gameManager.profile.emotionEquilibriums, .2f);

        // cap/floor energy
        runState.energy = System.Math.Max(runState.energy, 0);
        runState.energy = System.Math.Min(runState.energy, gameManager.profile.energyCap);

        // trigger whatever thought is active by the end of this activity
        if (runState.CurrentThought())
        {
            runState.CurrentThought().Effect(runState);
        }
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
        // depending on repeat probability, first determine if current activity is offered again
        if (runState.CurrentActivity())
        {
            float p = runState.CurrentActivity().repeatProbability;
            if (runState.CurrentThought())
            {
                p = runState.CurrentThought().Repeat(p);
            }
            if (Random.Range(0f, 1f) < p)
            {
                offeredActivities.Add(runState.CurrentActivity());
            }
        }
        // get all available activities (other than current)
        List<Activity> availableActivities = new List<Activity>();
        foreach (Activity activity in gameManager.profile.activities)
        {
            if (activity != runState.CurrentActivity())
            {
                for (int i = 0; i < activity.Availability(runState); i++)
                {
                    availableActivities.Add(activity);
                }
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
            // TODO: limit height differentials based on emotions!
            if (!crammed)
            {
                offeredActivities.Add(available);
            }
        }
        // TODO: there's got to be at least one activity lower than current!
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
            // right now it's just the first one in the list
            Thought filler = gameManager.profile.thoughts[0];
            return new List<Thought> { filler };
        }
        // select 3 random (with repeat)
        List<Thought> offeredThoughts = new List<Thought>();
        for (int i=0; i < 3; i++)
        {
            int r = Random.Range(0, availableThoughts.Count);
            offeredThoughts.Add(availableThoughts[r]);
        }
        return offeredThoughts;
    }
}
