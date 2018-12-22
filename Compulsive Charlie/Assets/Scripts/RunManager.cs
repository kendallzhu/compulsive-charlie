using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script managing all the state and gameplay of a run
public class RunManager : MonoBehaviour {
    public GameManager gameManager;
    public RunState runState;
    public PlayerController player;

    // prefabs
    public GameObject platformPrefab;

    // TODO: track which phase of game in variable, pass to player controller(?)

    // Initialization
    void Start () {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        Debug.Log(gameManager);
        // get initial runState (based on profile)
        runState = new RunState(0, new Dictionary<string, int>());

        // test - instantiate a new activity platform
        Activity testActivity = gameManager.activities[0];
        GameObject platform = Instantiate(platformPrefab);
        //platform.AddComponent(System.Type.GetType("ActivityPlatform"));
        Debug.Log(gameManager.activities[0]);
        platform.GetComponent<ActivityPlatform>().Initialize(testActivity, runState);
    }

    private void Update()
    {
        // [makshift] if fallen way down, end run and advance scenes
        if (player.transform.position.y < -100)
        {
            gameManager.EndRun(int.MinValue);
        }
    }
    // TODO: advance timesteps, spawn platforms as you go, offer thoughts
}
