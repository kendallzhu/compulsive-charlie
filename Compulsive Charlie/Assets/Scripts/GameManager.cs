using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // keep track of profile info
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
}
