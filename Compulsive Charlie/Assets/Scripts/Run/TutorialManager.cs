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
    public List<GameObject> SuppressionTutorial;
    public GameObject advanceText;

    // tracking which tutorial sequence is activated, and its status
    private List<GameObject> activeTutorial = null;
    private int activeIndex = 0;

    // tracking when this tutorial was activated (for timer)
    private const float minTimeShow = .5f;
    private float timeActivated;

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
        // activate canvas when we've just activated a new tutorial sequence
        if (activeTutorial != null && !canvas.activeSelf)
        {
            canvas.SetActive(true);
            if (activeTutorial.Count > 0)
            {
                activeTutorial[0].SetActive(true);
            }
            timeActivated = Time.realtimeSinceStartup;
        }
        // freeze time when tutorial active
        if (activeTutorial != null)
        {
            Time.timeScale = 0;
        }
        // close canvas when we've reached the end the tutorial
        if (activeTutorial != null && activeIndex >= activeTutorial.Count)
        {
            activeTutorial = null;
            activeIndex = 0;
            canvas.SetActive(false);
            Time.timeScale = 1;
        }
        // player advance tutorial
        if (CanAdvance())
        {
            advanceText.SetActive(true);
            if (Input.anyKeyDown)
            {
                Dismiss();
                timeActivated = Time.realtimeSinceStartup;
            }
        } else
        {
            advanceText.SetActive(false);
        }
    }

    private bool CanAdvance()
    {
        // disallow premature dismissals to prevent accidental skipping
        return activeTutorial != null && Time.realtimeSinceStartup - timeActivated > minTimeShow;
    }

    // activation functions (to be called from runManager)
    public void ActivateUITutorial()
    {
        activeTutorial = UITutorial;
        gameManager.showUITutorial = false;
    }

    public void ActivateThoughtTutorial()
    {
        activeTutorial = ThoughtTutorial;
        gameManager.showThoughtTutorial = false;
    }

    public void ActivateRhythmTutorial()
    {
        activeTutorial = RhythmTutorial;
        gameManager.showRhythmTutorial = false;
    }

    public void ActivateEmotionNoteTutorial()
    {
        activeTutorial = EmotionNoteTutorial;
        gameManager.showEmotionNoteTutorial = false;
    }

    public void ActivateSuppressionTutorial()
    {
        activeTutorial = SuppressionTutorial;
        gameManager.showSuppressionTutorial = false;
    }

    public void OnMissingALot()
    {
        gameManager.showRhythmTutorial = true;
        gameManager.showEmotionNoteTutorial = true;
    }

    // Skip entire tutorial
    public void Skip()
    {
        activeIndex = 0;
        activeTutorial = null;
        canvas.SetActive(false);
        Time.timeScale = 1;
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
