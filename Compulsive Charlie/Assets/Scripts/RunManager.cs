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
	
	// TODO: advance timesteps, spawn platforms, offer thoughts
}
