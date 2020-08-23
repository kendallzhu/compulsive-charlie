using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Overall manager for game, persistent accross scenes/runs
public class GameManager : MonoBehaviour {
    public GameObject allActivities;
    public GameObject allThoughts;
    public GameObject allUpgrades;

    // keep track of profile info
    public Profile profile;

    // tracking which tutorials need to be shown
    public bool showUITutorial = true;
    public bool showThoughtTutorial = true;
    public bool showRhythmTutorial = true;
    public bool showEmotionNoteTutorial = true;
    public bool showSuppressionTutorial = true;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start () {
        LoadSplash();
        // set starting profile of the game
        profile = new Profile();
        // load in all activities, thoughts and upgrades from the gameObjects (see editor)
        foreach (Transform child in allActivities.transform)
        {
            profile.activities.Add(child.gameObject.GetComponent<Activity>());
        }
        foreach (Transform child in allThoughts.transform)
        {
            profile.thoughts.Add(child.gameObject.GetComponent<Thought>());
        }
        foreach (Transform child in allUpgrades.transform)
        {
            profile.upgrades.Add(child.gameObject.GetComponent<Upgrade>());
        }
        profile.Reset();
    }

    public void StartGame()
    {
        // right now just goes to profile menu, in future could load some backstory scenes
        LoadProfile();
    }

    public void LoadSplash()
    {
        // go to splash screen
        SceneManager.LoadScene("IntroStory");
    }

    public void LoadProfile()
    {
        // go to profile menu
        SceneManager.LoadScene("Profile");
    }

    public void StartRun()
    {
        // go to run scene
        SceneManager.LoadScene("Run");
    }

    public void EndRun(RunState runState)
    {
        // record run and go to cut scene
        profile.allRuns.Add(runState);
        SceneManager.LoadScene("Recap");
    }

    public void SkipTutorials()
    {
        showUITutorial = false;
        showRhythmTutorial = false;
        showEmotionNoteTutorial = false;
        showThoughtTutorial = false;
        showSuppressionTutorial = false;
    }
}
