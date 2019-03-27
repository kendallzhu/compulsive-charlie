using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ThoughtMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject tutorialCanvas;
    public GameObject nameText;
    public GameObject descriptionText;
    public GameObject energyText;
    public GameObject jumpPowerText;
    private RunManager runManager;
    private Thought currentThought;
    private bool flipped;

    // one-time initialization (used instead of awake because it starts deactivated)
    public void Initialize()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        // get reference to parent canvas
        canvas = transform.parent.gameObject;
    }

    // take button input
    private void Update()
    {
        if (canvas && canvas.activeSelf && !tutorialCanvas.activeSelf)
        {
            Time.timeScale = 0;
            // todo: dpad/joystick selection
            bool blue = Input.GetButtonDown("blue");
            bool green = Input.GetButtonDown("green");
            bool yellow = Input.GetButtonDown("yellow");
            bool red = Input.GetButtonDown("red");
            if (yellow)
            {
                Accept();
            }
            else if (green)
            {
                Reject();
            }
            else if (blue || red)
            {
                Flip();
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
        // freeze time and activate canvas
        Time.timeScale = 0;
        canvas.SetActive(true);
        if (!nameText.activeSelf)
        {
            Flip();
        }
        nameText.GetComponent<TextMeshProUGUI>().color = currentThought.GetColor();
        nameText.GetComponent<TextMeshProUGUI>().text = currentThought.name;
        descriptionText.GetComponent<TextMeshProUGUI>().text = currentThought.descriptionText;
        energyText.GetComponent<TextMeshProUGUI>().text = currentThought.energyLevel.ToString();
        jumpPowerText.GetComponent<TextMeshProUGUI>().text = currentThought.jumpPower.ToString();
        // TODO: create a countdown timer to limit decision time?
    }

    // activate the thought and end sequence
    public void Accept()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        RunState runState = runManager.runState;
        runState.thoughtHistory.Add(currentThought);
        currentThought.AcceptEffect(runState);
        runManager.PostThoughtSelect();
    }

    // Redraw
    public void Reject()
    {
        // optional - disallow reject when no energy
        if (runManager.runState.energy == 0)
        {
            return;
        }
        Time.timeScale = 1;
        canvas.SetActive(false);
        if (runManager.runState.energy > 0)
        {
            currentThought.RejectEffect(runManager.runState);
            runManager.PreJump();
        }
        else
        {
            // rejecting when no energy left, with effect
            currentThought.RejectEffect(runManager.runState);
            runManager.PostThoughtSelect();
        }
    }
    
    // Toggle info
    public void Flip()
    {
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
