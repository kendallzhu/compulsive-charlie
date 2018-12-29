using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Script managing all the state and gameplay of a single run
public class RunManager : MonoBehaviour {
    public GameManager gameManager;
    public RunState runState;
    public PlayerController player;
    public new CameraController camera;

    // prefabs
    public GameObject platformPrefab;

    // Initialization
    void Awake () {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        // get initial runState (based on profile)
        runState = new RunState(0, new EmotionState());
    }

    private void Update()
    {
        // [makshift] if fallen way down, end run and advance scenes
        if (player.transform.position.y < -100)
        {
            gameManager.EndRun(int.MinValue);
        }
        // [makshift] if time limit exceeded, end run
        if (runState.timeSteps > gameManager.profile.timeLimit)
        {
            gameManager.EndRun(runState.CurrentScore());
        }
        // if near end of platform, zoom out for jump
        ActivityPlatform p = runState.CurrentActivityPlatform();
        if (p != null && p.x + p.length - player.transform.position.x < 3)
        {
            // TODO: dynamic zoom w/ parameter depening on platform heights
            camera.ZoomOut();
        } else
        {
            camera.ZoomNormal();
        }
    }

    // for when the player jumps to next set of activities, called via trigger in ActivityPlatform
    public void AdvanceTimeStep(ActivityPlatform newActivityPlatform)
    {
        if (newActivityPlatform != null)
        {
            // stop old platform spawning rhythm notes
            if (runState.activityHistory.Count > 0)
            {
                runState.activityHistory.Last().StopRhythm();
            }
            // increment timeSteps
            runState.timeSteps += 1;
            // update activity and score histories
            runState.activityHistory.Add(newActivityPlatform);
            runState.scoreHistory.Add(newActivityPlatform.y);
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

        // gradually bring emotion axes back to equilibrium levels
        // (TODO: certain activities can do this more strongly like sleep)
        runState.emotions.Equilibrate(gameManager.profile.emotionEquilibriums, .1f);

        // offer thoughts - TODO: freeze and provide a menu with a countdown timer
        foreach (Thought thought in SelectThoughts())
        {
            runState.thoughtHistory.Add(thought);
            thought.Effect(runState);
            // TODO: add another thought effect trigger at the end of the activityPlatform
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
        Thought testThought = gameManager.profile.thoughts[0];
        return new List<Thought> { testThought };
    }
}
