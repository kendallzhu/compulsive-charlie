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

    // tracking if the ful tutorial should be shown in next run
    public bool showTutorial = true;

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

        profile.defaultInitialEmotions = new EmotionState(5, 5, 5);
        profile.defaultInitialEnergy = 2;
        profile.defaultEnergyCap = 10;
        profile.defaultEnergyRegen = 0;

        profile.defaultSchedule = new List<Activity>();
        // ambitious schedule
        profile.defaultSchedule.Add(Object.FindObjectOfType<BalancedMeal>());
        profile.defaultSchedule.Add(Object.FindObjectOfType<Class>());
        profile.defaultSchedule.Add(Object.FindObjectOfType<BalancedMeal>());
        profile.defaultSchedule.Add(Object.FindObjectOfType<Study>());
        profile.defaultSchedule.Add(Object.FindObjectOfType<Walk>());
        profile.defaultSchedule.Add(Object.FindObjectOfType<BalancedMeal>());
        profile.defaultSchedule.Add(Object.FindObjectOfType<Study>());
        profile.defaultSchedule.Add(Object.FindObjectOfType<Study>());
        profile.defaultSchedule.Add(Object.FindObjectOfType<Shower>());
        profile.defaultSchedule.Add(Object.FindObjectOfType<GoToBed>());

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
        SceneManager.LoadScene(1);
    }

    public void LoadProfile()
    {
        // go to profile menu
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(2);
    }

    public void StartRun()
    {
        // go to run scene
        SceneManager.LoadScene(3);
    }

    public void EndRun(RunState runState)
    {
        // record run and go to cut scene
        profile.allRuns.Add(runState);
        SceneManager.LoadScene(4);
    }
}
