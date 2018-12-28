using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for handling the profile menu
// (All non-ui functions called through gameManager, so it can keep track of stuff)
public class ProfileMenu : MonoBehaviour
{
    public GameManager gameManager;

    // Use this for initialization
    void Awake()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    public void OnStart()
    {
        gameManager.StartRun();
    }
}
