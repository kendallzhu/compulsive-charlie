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

    // for when the player jumps to next set of activities, called via trigger in ActivityPlatform
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

        // spawn new set of platforms
        foreach (Activity activity in SelectActivities())
        {
            SpawnPlatform(activity);
        }

        // offer thoughts
        thoughtMenu.Activate(SelectThoughts());

        // return zoom to normal
        camera.ZoomNormal();
    }

    // for when the player enters the jump Pad
    public void EnterJumpPad(ActivityPlatform activityPlatform)
    {
        // Zoom out for jump
        // TODO: dynamic zoom w/ parameter depening on platform heights
        camera.ZoomOut();

        if (activityPlatform != null)
        {
            // stop platform spawning rhythm notes
            if (runState.activityHistory.Count > 0)
            {
                runState.activityHistory.Last().StopRhythm();
            }
        }

        // gradually bring emotion axes back to equilibrium levels
        // (TODO: certain activities can do this more strongly like sleep)
        runState.emotions.Equilibrate(gameManager.profile.emotionEquilibriums, .1f);

        // regenerate energy
        runState.energy += gameManager.profile.energyRegen;
        // cap energy
        runState.energy = System.Math.Min(runState.energy, gameManager.profile.energyCap);

        // trigger whatever thought is active by the end of this activity
        if (runState.thoughtHistory.Count > 0)
        {
            runState.thoughtHistory.Last().Effect(runState);
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
        // TODO: select one for each height range? if available?
        Activity testActivity = gameManager.profile.activities[0];
        Activity testActivityLow = gameManager.profile.activities[1];
        return new List<Activity> { testActivity, testActivityLow };
    }

    // select thoughts from pool of available
    private List<Thought> SelectThoughts()
    {
        // TODO: select 3 random, taking into account availability and activity association
        // associations should be 3x more likely, IDEA: CAN REPEAT, (this makes single associations more relevant)
        Thought testThought = gameManager.profile.thoughts[0];
        return new List<Thought> { testThought };
    }
}
