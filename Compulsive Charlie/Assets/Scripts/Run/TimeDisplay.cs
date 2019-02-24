using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of timesteps left - right now just text but hopefully will be nicer
public class TimeDisplay : MonoBehaviour {
    public RunManager runManager;
    private const float rotationStep = -0.1f;

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

        Transform disc = transform.Find("Disc");
        float targetRotation = 345 - ((float)runState.timeSteps / 20f * 360f) % 360;
        if (System.Math.Abs(disc.localRotation.eulerAngles.z - targetRotation) > System.Math.Abs(rotationStep)) {
            disc.Rotate(new Vector3(0, 0, rotationStep));
        }
    }
}
