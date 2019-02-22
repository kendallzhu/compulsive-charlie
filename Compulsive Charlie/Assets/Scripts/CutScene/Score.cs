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
        List<Activity> schedule = gameManager.profile.schedule;
        List<Activity> reality = lastRun.activityHistory.Select(ap=>ap.activity).ToList();
        int numCompleted = 0;
        for (int i = 0; i < schedule.Count; i++)
        {
            if (i+1 < reality.Count && schedule[i] == reality[i + 1])
            {
                numCompleted++;
            }
        }
        string completion = numCompleted.ToString() + "/" + schedule.Count.ToString();
        gameObject.GetComponent<TextMeshProUGUI>().text = "Schedule Completion: " + completion;
        // TODO: also show max money, other achievements?
    }
}
