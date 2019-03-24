using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

// script for displaying schedule completion
public class ScheduleCompletion : MonoBehaviour
{
    public GameManager gameManager;

    // Initialization
    void Start()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        RunState lastRun = gameManager.profile.allRuns.Last();
        // calculate schedule completion
        List<Activity> schedule = gameManager.profile.schedule;
        List<Activity> reality = lastRun.activityHistory.Select(ap => ap.activity).ToList();
        int numCompleted = 0;
        for (int i = 0; i < schedule.Count; i++)
        {
            if (i + 1 < reality.Count && schedule[i] == reality[i + 1])
            {
                numCompleted++;
            }
        }
        string completion = numCompleted.ToString() + "/" + schedule.Count.ToString();
        // load everything into the text box
        gameObject.GetComponent<TextMeshProUGUI>().text = "Schedule Completion: " + completion;
    }
}
