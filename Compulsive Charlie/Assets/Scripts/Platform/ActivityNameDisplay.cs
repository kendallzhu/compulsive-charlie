﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for marking activities and doing stuff related to if they have bonuses
// (should schedule colletable logic be elsewhere?)
public class ActivityNameDisplay : MonoBehaviour
{
    private GameManager gameManager;
    private RunManager runManager;
    public ActivityPlatform ap;
    public GameObject ScheduleCollectablePrefab;
    private GameObject scheduleCollectable;

    private Vector2 scheduleCollectableOffset;
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
        scheduleCollectableOffset = new Vector2(1.3f, .8f);
        if (ap.activity != null)
        {
            string prefix = ap.jumpNumber.ToString() + ") ";
            gameObject.GetComponent<TextMeshProUGUI>().text = prefix + ap.activity.name.ToString();
            // spawn collectible for scheduled activities
            if (gameManager.profile.GetSchedule(runManager.runState.timeSteps + 1) == ap.activity)
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = gameObject.GetComponent<TextMeshProUGUI>().text;
                scheduleCollectable = Instantiate(ScheduleCollectablePrefab, ap.transform);
                scheduleCollectable.transform.localPosition = scheduleCollectableOffset;

            }
        }
    }

    // standardize how visible something is based on its y position
    private float GetAlpha(float y)
    {
        return 1;
        float beamY = runManager.rhythmManager.hitArea.transform.position.y;
        float beamWidth = runManager.rhythmManager.beamWidth;
        float yDiff = Mathf.Abs(y - beamY) + .01f;
        float distFromBeam = yDiff - beamWidth / 2;
        return (1 - distFromBeam / 1.5f);
    }

    private void Update()
    {
        // make names less visible if they are outside of beam of light
        float alpha = GetAlpha(transform.position.y);
        // but always show the one you are on, for less confusion
        if (ap == runManager.runState.CurrentActivityPlatform())
        {
            alpha = Mathf.Max(alpha, .25f);
        }
        gameObject.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, alpha);
        if (scheduleCollectable)
        {
            float iconAlpha = GetAlpha(transform.position.y + scheduleCollectableOffset.y);
            scheduleCollectable.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, iconAlpha);
        }
    }
}
