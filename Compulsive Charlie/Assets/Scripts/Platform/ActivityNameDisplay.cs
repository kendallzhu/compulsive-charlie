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
            if (gameManager.profile.GetSchedule(runManager.runState.timeSteps + 1) == ap.activity)
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = "*" + gameObject.GetComponent<TextMeshProUGUI>().text;
            }
        }
    }

    private void Update()
    {
        // make names less visible if they are outside of beam of light
        float beamY = runManager.rhythmManager.hitArea.transform.position.y;
        float beamWidth = runManager.rhythmManager.beamWidth;
        float yDiff = Mathf.Abs(transform.position.y - beamY) + .01f;
        float distFromBeam = yDiff - beamWidth / 2;
        float alpha = 1 - distFromBeam / 1.5f;
        // but always show the one you are on, for less confusion
        if (ap == runManager.runState.CurrentActivityPlatform())
        {
            alpha = Mathf.Max(alpha, .25f);
        }
        gameObject.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, alpha);
    }
}
