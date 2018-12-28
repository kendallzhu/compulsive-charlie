using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for displaying score in cutscene - to improve
public class Score : MonoBehaviour
{
    public GameManager gameManager;

    // Initialization
    void Awake()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        List<int> scores = gameManager.profile.scores;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + scores[scores.Count - 1].ToString();
    }
}
