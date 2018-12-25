using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject allActivities;
    public GameObject allThoughts;
    public GameObject allUpgrades;

    // keep track of profile info
    public Profile profile;

    void Start () {
        //Debug.Log("game manager started");
        // this should be in preload scene, now load first scene
        SceneManager.LoadScene(1);

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
        SceneManager.LoadScene(3);
    }

    public void EndRun(int score)
    {
        // record score and go to cut scene (TODO: different based on score)
        profile.scores.Add(score);
        SceneManager.LoadScene(4);
    }
}
