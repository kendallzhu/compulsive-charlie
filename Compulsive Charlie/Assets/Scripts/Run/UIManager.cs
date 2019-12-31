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
    public GameObject scoreDisplay;
    public GameObject comboCounter;

    // display constants
    private const int emotionMeterCap = 20;
    private const float timeRotationStep = -0.1f;
    private Dictionary<EmotionType, Color> emotionFillColors;

    // Initialization
    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        // record emotion fill colors
        emotionFillColors = new Dictionary<EmotionType, Color>();
        emotionFillColors.Add(EmotionType.anxiety, anxietyMeter.transform.Find("Filler").GetComponent<Image>().color);
        emotionFillColors.Add(EmotionType.frustration, frustrationMeter.transform.Find("Filler").GetComponent<Image>().color);
        emotionFillColors.Add(EmotionType.despair, despairMeter.transform.Find("Filler").GetComponent<Image>().color);
    }

    void Update()
    {
        RunState runState = runManager.runState;
        EmotionState e = runState.emotions;
        // fill meters
        List<int> values = new List<int> { runState.energy, e.despair, e.anxiety, e.frustration };
        int emoCap = emotionMeterCap;
        List<int> caps = new List<int> { gameManager.profile.energyCap, emoCap, emoCap, emoCap };
        List<GameObject> meters = new List<GameObject> { energyMeter, despairMeter, anxietyMeter, frustrationMeter };
        for (int i = 0; i < meters.Count; i++)
        {
            // Find filler image (meters must have a child called "Filler")
            Image fillerImage = meters[i].transform.Find("Filler").GetComponent<Image>();
            fillerImage.type = Image.Type.Filled;
            fillerImage.fillMethod = Image.FillMethod.Horizontal;
            float newFillAmount = Mathf.Min(1, (float)values[i] / (float)caps[i]);
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

            // color gray and draw X if being suppressed
            EmotionType emotionType = EmotionType.None;
            if (meters[i] == anxietyMeter) emotionType = EmotionType.anxiety;
            if (meters[i] == frustrationMeter) emotionType = EmotionType.frustration;
            if (meters[i] == despairMeter) emotionType = EmotionType.despair;
            Activity activity = runState.CurrentActivity();
            if (activity && activity.suppressedEmotions.Contains(emotionType)) {
                fillerImage.color = new Color(.3f, .3f, .3f);
                Image XMark = meters[i].transform.Find("XMark").GetComponent<Image>();
                XMark.color = emotionFillColors[emotionType];
                XMark.enabled = true;
            } else if (emotionType != EmotionType.None)
            {
                fillerImage.color = emotionFillColors[emotionType];
                Image XMark = meters[i].transform.Find("XMark").GetComponent<Image>();
                XMark.enabled = false;
            }
            // set text (meters must have a child called "Text")
            Transform textObject = meters[i].transform.Find("Text");
            if (textObject)
            {
                textObject.GetComponent<TextMeshProUGUI>().text = values[i].ToString();
            }
        };
        // rotate timer wheel (must have a child called "Disc")
        Transform disc = timerWheel.transform.Find("Disc");
        float targetRotation = 345 - ((float)runState.timeSteps / 15f * 360f) % 360;
        if (System.Math.Abs(disc.localRotation.eulerAngles.z - targetRotation) > System.Math.Abs(timeRotationStep))
        {
            disc.Rotate(new Vector3(0, 0, timeRotationStep));
        }
        // update the score display
        Transform scoreText = scoreDisplay.transform.Find("Text");
        if (scoreText)
        {
            scoreText.GetComponent<TextMeshProUGUI>().text = runState.score.ToString();
        }
        Transform scoreMultiplierText = scoreDisplay.transform.Find("MultiplierText");
        if (scoreMultiplierText)
        {
            string multiplierString = runState.scoreMultiplier.ToString() + "x";
            scoreMultiplierText.GetComponent<TextMeshProUGUI>().text = multiplierString;
            scoreMultiplierText.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0);
            if (runState.scoreMultiplier < 1)
            {
                scoreMultiplierText.GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0);
            }
            if (runState.scoreMultiplier > 1)
            {
                scoreMultiplierText.GetComponent<TextMeshProUGUI>().color = new Color(0, 255, 0);
            }
        }
        Transform comboText = comboCounter.transform.Find("Text");
        if (comboText)
        {
            string comboString = "x" + runState.rhythmCombo.ToString();
            if (comboString != comboText.GetComponent<TextMeshProUGUI>().text)
            {
                comboText.GetComponent<FadeTMPro>().Reset();
            }
            comboText.GetComponent<TextMeshProUGUI>().text = comboString;
        }
    }
}
