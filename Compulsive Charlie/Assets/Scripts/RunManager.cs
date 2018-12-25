using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script managing all the state and gameplay of a run
public class RunManager : MonoBehaviour {
    public GameManager gameManager;
    public RunState runState;
    public PlayerController player;
    public CameraController camera;

    // prefabs
    public GameObject platformPrefab;

    // TODO: track which phase of game in variable, pass to player controller(no?)

    // Initialization
    void Start () {
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
            // increment timeSteps
            runState.timeSteps += 1;
            // update activity and score histories
            runState.activityHistory.Add(newActivityPlatform);
            runState.scoreHistory.Add(newActivityPlatform.y);
        }

        // spawn new set of platforms - TODO: select from pool of available, etc.
        Activity testActivity = gameManager.profile.activities[0];
        SpawnPlatform(testActivity);
    }

    // instantiate a new activity platform
    private void SpawnPlatform(Activity activity)
    {
        GameObject platform = Instantiate(platformPrefab);
        platform.GetComponent<ActivityPlatform>().Initialize(activity, this);
    }
    // TODO: advance timesteps, spawn platforms as you go, offer thoughts
}
