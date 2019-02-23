using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of energy - right now just text but hopefully will be nicer
public class EnergyDisplay : MonoBehaviour
{
    public float maxBarSize;
    public float barThickness;

    public RunManager runManager;
    public GameManager gameManager;

    // Initialization
    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        RunState runState = runManager.runState;
        transform.Find("Text").GetComponent<TextMeshProUGUI>().text = runState.energy.ToString();
        // set bar
        float maxEnergy = gameManager.profile.energyCap;
        float energy = runManager.runState.energy;
        float size = maxBarSize * energy / maxEnergy;
        transform.Find("Bar").localScale = new Vector3(size, barThickness, 1f);
    }
}
