using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

// script for graphic display of active thought - right now just text but hopefully will be nicer
public class ThoughtDisplay : MonoBehaviour
{
    public RunManager runManager;

    // Initialization
    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    void Update()
    {
        Thought currentThought = runManager.runState.CurrentThought();
        if (currentThought)
        {
            string quote = "\"" + currentThought.name + "\"";
            gameObject.GetComponent<TextMeshProUGUI>().text =  quote;
        }
    }
}
