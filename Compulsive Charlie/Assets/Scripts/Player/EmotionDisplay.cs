using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of aggregate emotion - right now just text but hopefully will be nicer
public class EmotionDisplay : MonoBehaviour
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
        string dominantEmotion = runState.emotions.GetDominantEmotion();
        int extremeness = runState.emotions.Extremeness();
        gameObject.GetComponent<TextMeshProUGUI>().text = dominantEmotion + ":" + extremeness.ToString();
    }
}
