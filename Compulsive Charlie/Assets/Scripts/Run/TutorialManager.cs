using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// class for managing popup + dismissal tutorial sequences
public class TutorialManager : MonoBehaviour
{
    public GameObject canvas;
    private RunManager runManager;
    private GameManager gameManager;

    public List<GameObject> UITutorial;
    public List<GameObject> ThoughtTutorial;
    public List<GameObject> RhythmTutorial;
    public List<GameObject> EmotionNoteTutorial;

    // tracking if each tutorial has been shown yet in current run
    public bool shownUITutorial = false;
    public bool shownThoughtTutorial = false;
    public bool shownRhythmTutorial = false;
    public bool shownEmotionNoteTutorial = false;

    // tracking which tutorial sequence is activated, and its status
    private List<GameObject> activeTutorial = null;
    private int activeIndex = 0;

    public void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        gameManager = Object.FindObjectOfType<GameManager>();
        canvas.SetActive(false);
    }

    // take button input for dismissal
    private void Update()
    {
        // activate canvas when we've just activated a new tutorial
        if (activeTutorial != null && !canvas.activeSelf)
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
            if (activeTutorial.Count > 0)
            {
                activeTutorial[0].SetActive(true);
            }
        }
        // close canvas when we've reached the end the tutorial
        if (activeTutorial != null && activeIndex >= activeTutorial.Count)
        {
            activeTutorial = null;
            activeIndex = 0;
            canvas.SetActive(false);
            Time.timeScale = 1;
        }
        // if tutorial is in progress - take user input
        if (activeTutorial != null)
        {
            Time.timeScale = 0;
            bool left = Input.GetButtonDown("left");
            bool down = Input.GetButtonDown("down");
            bool up = Input.GetButtonDown("up");
            bool right = Input.GetButtonDown("right");
            bool start = Input.GetButtonDown("start");
            bool back = Input.GetButtonDown("back");
            if (Input.anyKeyDown)
            {
                Dismiss();
            }
        }
    }

    // activation functions (to be called from runManager)
    public void ActivateUITutorial()
    {
        activeTutorial = UITutorial;
        shownUITutorial = true;
    }

    public void ActivateThoughtTutorial()
    {
        activeTutorial = ThoughtTutorial;
        shownThoughtTutorial = true;
    }

    public void ActivateRhythmTutorial()
    {
        activeTutorial = RhythmTutorial;
        shownRhythmTutorial = true;
    }

    public void ActivateEmotionNoteTutorial()
    {
        activeTutorial = EmotionNoteTutorial;
        shownEmotionNoteTutorial = true;
    }

    // Dismisses current element of active tutorial sequence
    // move on to the next element, or end
    private void Dismiss()
    {
        activeTutorial[activeIndex].SetActive(false);
        activeIndex++;
        if (activeIndex < activeTutorial.Count)
        {
            activeTutorial[activeIndex].SetActive(true);
        }
    }

    // Go back to previous element of active tutorial sequence
    private void Back()
    {
        if (activeIndex == 0)
        {
            return;
        }
        activeTutorial[activeIndex].SetActive(false);
        activeIndex--;
        activeTutorial[activeIndex].SetActive(true);
    }
}
