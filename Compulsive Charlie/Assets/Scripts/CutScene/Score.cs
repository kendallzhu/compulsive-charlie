using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

// script for displaying score in cutscene - to improve
public class Score : MonoBehaviour
{
    public GameManager gameManager;

    // Initialization
    void Awake()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        RunState lastRun = gameManager.profile.allRuns.Last();
        // TODO: also show max money, other achievements?
        gameObject.GetComponent<TextMeshProUGUI>().text = "Time Lasted: " + lastRun.timeSteps.ToString();
    }
}
