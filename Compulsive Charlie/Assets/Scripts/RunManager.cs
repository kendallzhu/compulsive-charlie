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

    // TODO: track which phase of game in variable, pass to player controller(no?)

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
        if (p != null && p.x + p.length - player.transform.position.x < 4)
        {
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

        // spawn new set of platforms - TODO: function to select from pool of available
        Activity testActivity = gameManager.profile.activities[0];
        SpawnPlatform(testActivity);
        Activity testActivityLow = gameManager.profile.activities[1];
        SpawnPlatform(testActivityLow);
    }

    // instantiate a new activity platform
    private void SpawnPlatform(Activity activity)
    {
        GameObject platform = Instantiate(platformPrefab);
        platform.GetComponent<ActivityPlatform>().Initialize(activity);
        // add it to list of prospective platforms in runState
        runState.spawnedPlatforms.Add(platform.GetComponent<ActivityPlatform>());
    }
    // TODO: offer thoughts
}
