using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // keep track of profile info - TODO: modularize this into a class? Modularize emotions as well?
    public List<Thought> thoughts;
    public List<Activity> activities;
    public List<Upgrade> upgrades;
    public Dictionary<string, int> emotionEquilibriums;

    public List<int> scores;

	void Start () {
        Debug.Log("game manager started");
        // this should be in preload scene, now load first scene
        SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        // right now just goes to profile menu, in future could load some backstory scenes
        LoadProfile();
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(3);
    }

    public void EndRun()
    {
        // go to run scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(4);
    }
}
