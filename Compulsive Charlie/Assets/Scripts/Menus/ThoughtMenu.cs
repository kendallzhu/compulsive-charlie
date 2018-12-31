using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThoughtMenu : MonoBehaviour {
    private GameObject canvas;
    private RunManager runManager;
    private List<Thought> thoughts;

	// one-time initialization (used instead of awake because it starts deactivated)
	public void Initialize () {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        // get reference to parent canvas
        canvas = transform.parent.gameObject;
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
            gameObject.transform.Find("Option1Button"),
            gameObject.transform.Find("Option2Button"),
            gameObject.transform.Find("Option3Button")
        };
        for (int i = 0; i < thoughts.Count; i++)
        {
            Transform card = cards[i];
            GameObject nameText = card.Find("NameText").gameObject;
            GameObject descriptionText = card.Find("DescriptionText").gameObject;
            nameText.GetComponent<TextMeshProUGUI>().text = thoughts[i].name;
            descriptionText.GetComponent<TextMeshProUGUI>().text = thoughts[i].descriptionText;
        }
        // TODO: hide/disable extra cards if < 3 provided?
        // TODO: create a countdown timer to limit decision time
    }

    // Functions for selecting a thought and closing menu
    public void Select1()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        // trigger the selected thought effect
        RunState runState = runManager.runState;
        runState.thoughtHistory.Add(thoughts[0]);
        thoughts[0].Effect(runState);
    }

    public void Select2()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        // trigger the selected thought effect
        RunState runState = runManager.runState;
        runState.thoughtHistory.Add(thoughts[1]);
        thoughts[1].Effect(runState);
    }

    public void Select3()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        // trigger the selected thought effect
        RunState runState = runManager.runState;
        runState.thoughtHistory.Add(thoughts[2]);
        thoughts[2].Effect(runState);
    }
}
