using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of score - right now just text but hopefully will be nicer
public class ScoreDisplay : MonoBehaviour
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
        int score = runManager.runState.CurrentScore();
        gameObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
