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
        gameObject.GetComponent<TextMeshProUGUI>().text = "Craving: " + runManager.runState.craving.ToString();
    }
}
