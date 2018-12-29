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
        List<Thought> thoughtHistory = runManager.runState.thoughtHistory ;
        if (thoughtHistory.Count > 0)
        {
            Thought activeThought = thoughtHistory.Last();
            string quote = "\"" + activeThought.name + "\"";
            gameObject.GetComponent<TextMeshProUGUI>().text =  quote;
        }
    }
}
