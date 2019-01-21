using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of timesteps left - right now just text but hopefully will be nicer
public class TimeDisplay : MonoBehaviour {
    public RunManager runManager;

    // Initialization
    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    void Update()
    {
        RunState runState = runManager.runState;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Time: " + runState.timeSteps.ToString();
    }
}
