﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ThoughtMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject rejectButton;
    public GameObject tutorialCanvas;
    public GameObject nameText;
    public GameObject descriptionText;
    public GameObject energyText;
    public GameObject rejectEnergyText;
    public GameObject rejectLabelText;
    public GameObject rejectEnergyIcon;
    public GameObject jumpPowerText;
    private RunManager runManager;
    public Thought currentThought;

    public void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        canvas.SetActive(false);
    }

    // take button input
    private void Update()
    {
        if (canvas && canvas.activeSelf && !tutorialCanvas.activeSelf)
        {
            // Time.timeScale = 0;
            // todo: dpad/joystick selection
            bool left = Input.GetButtonDown("left");
            bool down = Input.GetButtonDown("down");
            bool up = Input.GetButtonDown("up");
            bool right = Input.GetButtonDown("right");
            if (up)
            {
                Accept();
            }
            else if (down)
            {
                Reject();
            }
            else if (right || left)
            {
                Flip();
            }
            // deactivate reject button when no energy
            if (runManager.runState.energy == 0)
            {
                rejectButton.SetActive(false);
            } else
            {
                rejectButton.SetActive(true);
            }
        }
    }

    // activate the menu with a countdown timer
    public void Activate(List<Thought> thoughts)
    {
        // right now we should only be displaying 3 thoughts
        if (thoughts.Count == 0)
        {
            Debug.Log("need at least 1 thought passed into thought menu");
        }
        currentThought = thoughts[0];
        runManager.runState.thoughtHistory.Add(currentThought);
        // freeze time and activate canvas
        // Time.timeScale = 0;
        canvas.SetActive(true);
        /*if (!nameText.activeSelf)
        {
            Flip();
        }*/
        // nameText.GetComponent<TextMeshProUGUI>().color = currentThought.GetColor();
        // nameText.GetComponent<TextMeshProUGUI>().text = currentThought.name;
        // descriptionText.GetComponent<TextMeshProUGUI>().text = currentThought.descriptionText;
        energyText.GetComponent<TextMeshProUGUI>().text = "-" + currentThought.energyCost.ToString();
        rejectEnergyText.GetComponent<TextMeshProUGUI>().text = runManager.FreeRejectThought() ? "FREE" : "-1";
        rejectLabelText.GetComponent<TextMeshProUGUI>().text = runManager.FreeRejectThought() ? "Let Go" : "Think";
        rejectEnergyIcon.SetActive(!runManager.FreeRejectThought());
        // jumpPowerText.GetComponent<TextMeshProUGUI>().text = currentThought.maxJumpPower.ToString();*/
        // TODO: create a countdown timer to limit decision time?
    }

    // activate the thought and end sequence
    public void Accept()
    {
        // Time.timeScale = 1;
        canvas.SetActive(false);
        RunState runState = runManager.runState;
        runState.thoughtHistory.Add(currentThought);
        currentThought.AcceptEffect(runState);
        runManager.PostThoughtSelect();
        currentThought = null;
    }

    // Redraw
    public void Reject()
    {
        // optional - disallow reject when no energy
        if (runManager.runState.energy == 0)
        {
            return;
        }
        runManager.runState.thoughtHistory.RemoveAt(runManager.runState.thoughtHistory.Count - 1);
        if (runManager.FreeRejectThought())
        {
            runManager.PreJump();
            return;   
        }
        if (runManager.runState.energy > 0)
        {
            currentThought.RejectEffect(runManager.runState);
            runManager.PreJump();
        }
        else
        {
            // rejecting when no energy left, with effect
            currentThought.RejectEffect(runManager.runState);
        }
    }

    // Toggle info
    public void Flip()
    {
        return;
        if (!nameText.activeSelf)
        {
            nameText.SetActive(true);
            descriptionText.SetActive(false);
        }
        else
        {
            nameText.SetActive(false);
            descriptionText.SetActive(true);
        }
    }
}
