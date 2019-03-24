using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ThoughtMenu : MonoBehaviour
{
    public GameObject canvas;
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
        if (canvas && canvas.activeSelf)
        {
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

        nameText.GetComponent<TextMeshProUGUI>().color = currentThought.GetColor();
        nameText.GetComponent<TextMeshProUGUI>().text = currentThought.name;
        descriptionText.GetComponent<TextMeshProUGUI>().text = currentThought.descriptionText;
        energyText.GetComponent<TextMeshProUGUI>().text = currentThought.energyCost.ToString();
        jumpPowerText.GetComponent<TextMeshProUGUI>().text = currentThought.jumpPower.ToString();
        // TODO: create a countdown timer to limit decision time?
    }

    // activate the thought and end sequence
    public void Accept()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        RunState runState = runManager.runState;
        Thought chosenThought = currentThought;
        runState.thoughtHistory.Add(chosenThought);
        chosenThought.Effect(runState);
        runManager.PostThoughtSelect();
    }

    // Redraw
    public void Reject()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        // currentThought.RejectEffect(runState);
        runManager.PreJump();
    }
    
    // Toggle info
    public void Flip()
    {
        
    }
}
