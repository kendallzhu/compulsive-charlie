using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of aggregate emotion - right now just text but hopefully will be nicer
public class EmotionDisplay : MonoBehaviour
{
    public RunManager runManager;

    // Initialization
    void Start()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    void Update()
    {
        RunState runState = runManager.runState;
        int value = runManager.runState.emotions.GetTotal();
        gameObject.GetComponent<TextMeshProUGUI>().text = value.ToString();
    }
}
