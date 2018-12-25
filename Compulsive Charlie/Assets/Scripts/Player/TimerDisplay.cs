using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of timesteps left - right now just text but hopefully will be nicer
public class TimerDisplay : MonoBehaviour {
    public RunManager runManager;
    private int timeLeft = 0;

    // Initialization
    void Start()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    void Update()
    {
        RunState runState = runManager.runState;
        timeLeft = runManager.gameManager.profile.timeLimit - runState.timeSteps;
        gameObject.GetComponent<TextMeshProUGUI>().text = timeLeft.ToString();
    }
}
