using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for handling the initial menu when game is started
// (All functions called through gameManager, so it can keep track of stuff)
public class StartMenu : MonoBehaviour {
    public GameManager gameManager;

    // Use this for initialization
    void Start () {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    public void OnPlay()
    {
        gameManager.StartGame();
    }   
}
