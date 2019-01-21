using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of score - right now just text but hopefully will be nicer
public class MoneyDisplay : MonoBehaviour
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
        gameObject.GetComponent<TextMeshProUGUI>().text = "$" + runManager.runState.money.ToString();
    }
}
