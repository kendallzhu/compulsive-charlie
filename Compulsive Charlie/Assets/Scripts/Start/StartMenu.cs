using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for handling the initial menu when game is started
// (All functions called through gameManager, so it can keep track of stuff)
public class StartMenu : MonoBehaviour {
    public GameManager gameManager;

    // Use this for initialization
    void Awake () {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        // if no gameManager, load preload scene first
        if (gameManager == null)
        {
            SceneManager.LoadScene(0);
            return;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("start"))
        {
            OnPlay();
        }
    }

    public void OnPlay()
    {
        gameManager.StartGame();
    }   
}
