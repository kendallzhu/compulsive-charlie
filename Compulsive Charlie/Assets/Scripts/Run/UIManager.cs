using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// script for updating the UI meters
public class UIManager : MonoBehaviour
{
    public RunManager runManager;
    public GameManager gameManager;
    // refs to UI elements to manage
    public GameObject energyMeter;
    public GameObject despairMeter;
    public GameObject anxietyMeter;
    public GameObject frustrationMeter;
    public GameObject timerWheel;

    // display constants
    private const int emotionMeterCap = 20;
    private const float timeRotationStep = -0.1f;

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
        EmotionState e = runState.emotions;
        // fill meters
        List<int> values = new List<int> { runState.energy, e.despair, e.anxiety, e.frustration };
        List<int> caps = new List<int> { gameManager.profile.energyCap, emotionMeterCap, emotionMeterCap, emotionMeterCap };
        List<GameObject> meters = new List<GameObject> { energyMeter, despairMeter, anxietyMeter, frustrationMeter };
        for (int i = 0; i < meters.Count; i++)
        {
            // Find filler image (meters must have a child called "Filler")
            Image fillerImage = meters[i].transform.Find("Filler").GetComponent<Image>();
            fillerImage.type = Image.Type.Filled;
            fillerImage.fillMethod = Image.FillMethod.Horizontal;
            float newFillAmount = (float)values[i] / (float)caps[i];
            // activate change markers
            Transform increaseMarker = meters[i].transform.Find("IncreaseMarker");
            if (increaseMarker)
            {
                if (newFillAmount > fillerImage.fillAmount)
                {
                    increaseMarker.GetComponent<FadeImage>().Reset();
                }
            }
            // set filler image fill amount
            fillerImage.fillAmount = newFillAmount;
            // set text (meters must have a child called "Text")
            meters[i].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = values[i].ToString();
        };
        // rotate timer wheel (must have a child called "Disc")
        Transform disc = timerWheel.transform.Find("Disc");
        float targetRotation = 345 - ((float)runState.timeSteps / 20f * 360f) % 360;
        if (System.Math.Abs(disc.localRotation.eulerAngles.z - targetRotation) > System.Math.Abs(timeRotationStep))
        {
            disc.Rotate(new Vector3(0, 0, timeRotationStep));
        }
    }
}
