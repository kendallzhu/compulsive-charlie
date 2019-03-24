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
    void Start()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        // sort activities by best combo
        List<ActivityPlatform> history = gameManager.profile.allRuns.Last().activityHistory;
        List<ActivityPlatform> sortedHistory = history.OrderBy(ap => -ap.bestCombo).ToList();

        // retrieve name and best combos for each activity
        List<string> activityNames = history.Select(ap => ap.activity.name).ToList();
        List<int> bestCombos = sortedHistory.Select(ap => ap.bestCombo).ToList();
        string comboStrings = "";
        for (int i = 0; i < sortedHistory.Count && i < 5; i++)
        {
            comboStrings += activityNames[i] + ": " + bestCombos[i].ToString() + "\n";
        }

        // load everything into the text box
        gameObject.GetComponent<TextMeshProUGUI>().text = comboStrings;
    }
}
