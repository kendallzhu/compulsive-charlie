using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject canvas;
    private GameManager gameManager;
    private bool paused = false;

    private void Awake()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // pause menu
        if (!paused && (Input.GetButtonDown("start") || Input.GetButtonDown("back")))
        {
            Pause();
        }
        else if (paused)
        {
            if (Input.GetButtonDown("start"))
            {
                Resume();
            }
            if (Input.GetButtonDown("back"))
            {
                Restart();
            }
        }
    }

    public void Pause()
    {
        canvas.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public void Restart()
    {
        canvas.SetActive(false);
        paused = false;
        Time.timeScale = 1;
        gameManager.LoadProfile();
    }
}
