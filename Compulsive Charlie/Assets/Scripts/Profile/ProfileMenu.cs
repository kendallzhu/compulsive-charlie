using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// Script for handling the profile menu
// (All non-ui functions called through gameManager, so it can keep track of stuff)
public class ProfileMenu : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject scheduleText;

    // Use this for initialization
    void Awake()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        // if no gameManager, load preload scene first
        if (gameManager == null)
        {
            SceneManager.LoadScene(0);
            return;
        }
        // initialize the schedule text
        // scheduleText.GetComponent<TextMeshProUGUI>().text = "activity 1 \n activity 2";
    }

    private void Update()
    {
        if (Input.GetButtonDown("back"))
        {
            gameManager.LoadSplash();
        }
        else if (Input.anyKeyDown)
        {
            OnStart();
        }
    }

    public void OnStart()
    {
        gameManager.StartRun();
    }
}
