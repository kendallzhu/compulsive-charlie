using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script managing all the state and gameplay of a run
public class RunManager : MonoBehaviour {
    public GameManager gameManager;
    public RunState runState;
    public PlayerController player;

    // TODO: track which phase of game in variable, pass to player controller(?)

	// Initialization
	void Start () {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        Debug.Log(gameManager);
        // get initial runState (based on profile)
        runState = new RunState(0, new Dictionary<string, int>());
    }

    private void Update()
    {
        // makshift way to end run and advance scenes 
        if (player.transform.position.y < -100)
        {
            gameManager.EndRun();
        }
    }
    // TODO: advance timesteps, spawn platforms, offer thoughts
}
