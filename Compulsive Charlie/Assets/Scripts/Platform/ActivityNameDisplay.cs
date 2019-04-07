using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of timesteps left - right now just text but hopefully will be nicer
public class ActivityNameDisplay : MonoBehaviour
{
    private GameManager gameManager;
    private RunManager runManager;
    public ActivityPlatform ap;

    // Initialization
    void Start()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();

        // set activity platform label (todo: make nicer!)
        GameObject platform = this.transform.parent.transform.parent.gameObject;
        ap = platform.GetComponent<ActivityPlatform>();
        if (ap.activity != null)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = ap.activity.name.ToString();
            // mark scheduled activities
            if (gameManager.profile.GetSchedule(runManager.runState.timeSteps) == ap.activity)
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = "*" + gameObject.GetComponent<TextMeshProUGUI>().text;
            }
        }
    }
}
