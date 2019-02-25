using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
        // get reference to image display
        transform.Find("Filler").GetComponent<Image>().type = Image.Type.Filled;
        transform.Find("Filler").GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;
    }

    void Update()
    {
        RunState runState = runManager.runState;
        transform.Find("Text").GetComponent<TextMeshProUGUI>().text = runState.energy.ToString();
        // set bar
        float maxEnergy = gameManager.profile.energyCap;
        float energy = runManager.runState.energy;
        float size = maxBarSize * energy / maxEnergy;
        transform.Find("Filler").GetComponent<Image>().fillAmount = energy / maxEnergy;
    }
}
