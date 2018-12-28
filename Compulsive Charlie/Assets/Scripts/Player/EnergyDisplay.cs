using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of energy - right now just text but hopefully will be nicer
public class EnergyDisplay : MonoBehaviour
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
        RunState runState = runManager.runState;
        gameObject.GetComponent<TextMeshProUGUI>().text = runState.energy.ToString();
    }
}
