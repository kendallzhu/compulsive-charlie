using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of craving - right now just text but hopefully will be nicer
public class CravingDisplay : MonoBehaviour
{
    public RunManager runManager;

    // Initialization
    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    void Update()
    {
        string cravingString = "Craving: " + runManager.runState.craving.ToString();
        string multiplierString = " (X" + runManager.runState.cravingMultiplier.ToString() + ")";
        gameObject.GetComponent<TextMeshProUGUI>().text = cravingString + multiplierString;
    }
}
