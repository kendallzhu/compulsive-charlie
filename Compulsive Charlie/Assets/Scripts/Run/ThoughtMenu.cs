using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ThoughtMenu : MonoBehaviour
{
    private GameObject canvas;
    private RunManager runManager;
    private List<Thought> thoughts = new List<Thought>();

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
        // todo: dpad/joystick selection
        bool b1 = Input.GetButtonDown("blue");
        bool b2 = Input.GetButtonDown("green") || Input.GetButtonDown("yellow");
        bool b3 = Input.GetButtonDown("red");
        if (b1 && thoughts.Count >= 1)
        {
            Select1();
        }
        else if (b2 && thoughts.Count >= 2)
        {
            Select2();
        }
        else if (b3 && thoughts.Count >= 3)
        {
            Select3();
        }
    }

    // activate the menu with a countdown timer
    public void Activate(List<Thought> _thoughts)
    {
        // right now we should only be displaying 3 thoughts
        if (_thoughts.Count == 0)
        {
            Debug.Log("need at least 1 thought passed into thought menu");
        }
        if (_thoughts.Count > 3)
        {
            Debug.Log("Too many thoughts passed into thought menu");
        }
        thoughts = _thoughts;
        // freeze time and activate canvas
        Time.timeScale = 0;
        canvas.SetActive(true);
        // set the contents of cards properly
        List<Transform> cards = new List<Transform> {
            gameObject.transform.Find("ThoughtCard1"),
            gameObject.transform.Find("ThoughtCard2"),
            gameObject.transform.Find("ThoughtCard3")
        };
        for (int i = 0; i < 3; i++)
        {
            Transform card = cards[i];
            GameObject nameText = card.Find("NameText").gameObject;
            GameObject descriptionText = card.Find("DescriptionText").gameObject;
            GameObject energyText = card.Find("EnergyText").gameObject;
            GameObject jumpPowerText = card.Find("JumpPowerText").gameObject;

            GameObject upArrowIcon = card.Find("UpArrowIcon").gameObject;
            GameObject rethinkIcon = card.Find("RethinkIcon").gameObject;
            // show only cards which thoughts are provided
            if (i < thoughts.Count)
            {
                card.gameObject.SetActive(true);
                card.GetComponent<Image>().color = thoughts[i].GetColor();
                nameText.GetComponent<TextMeshProUGUI>().text = thoughts[i].name;
                descriptionText.GetComponent<TextMeshProUGUI>().text = thoughts[i].descriptionText;
                energyText.GetComponent<TextMeshProUGUI>().text = thoughts[i].energyCost.ToString();
                jumpPowerText.GetComponent<TextMeshProUGUI>().text = thoughts[i].jumpPower.ToString();
                // add a rethinking icon for cards that cause rethink
                if (thoughts[i].rethink)
                {
                    upArrowIcon.SetActive(false);
                    rethinkIcon.SetActive(true);

                }
                else
                {
                    upArrowIcon.SetActive(true);
                    rethinkIcon.SetActive(false);
                }
            }
            else
            {
                card.gameObject.SetActive(false);
            }

        }
        // TODO: create a countdown timer to limit decision time
    }

    // Functions for selecting a thought and closing menu
    public void Select1()
    {
        SelectThought(0);
    }

    public void Select2()
    {
        SelectThought(1);
    }

    public void Select3()
    {
        SelectThought(2);
    }

    public void SelectThought(int index)
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        // trigger the selected thought effect
        RunState runState = runManager.runState;
        Thought chosenThought = thoughts[index];
        runState.thoughtHistory.Add(chosenThought);
        chosenThought.Effect(runState);
        if (chosenThought.rethink)
        {
            runManager.PreJump();
        }
        else
        {
            runManager.PostThoughtSelect();
        }
    }
}
