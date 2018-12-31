using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FullEmotionDisplay : MonoBehaviour {
    public RunManager runManager;

    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    // keep display up to date
    void Update () {
        RunState runState = runManager.runState;
        EmotionState emotions = runState.emotions;
        // set the data for each emotion axis - TODO: make actual UI
        Transform cravingContentment = gameObject.transform.Find("CravingContentment");
        Transform anxietyTrust = gameObject.transform.Find("AnxietyTrust");
        Transform fearCuriosity = gameObject.transform.Find("FearCuriosity");
        Transform frustrationAcceptance = gameObject.transform.Find("FrustrationAcceptance");
        Transform confusionClarity = gameObject.transform.Find("ConfusionClarity");
        Transform despairJoy = gameObject.transform.Find("DespairJoy");
        Transform shameDignity = gameObject.transform.Find("ShameDignity");
        cravingContentment.GetComponent<TextMeshProUGUI>().text = "" + emotions.cravingContentment;
        anxietyTrust.GetComponent<TextMeshProUGUI>().text = "" + emotions.anxietyTrust;
        fearCuriosity.GetComponent<TextMeshProUGUI>().text = "" + emotions.fearCuriosity;
        frustrationAcceptance.GetComponent<TextMeshProUGUI>().text = "" + emotions.frustrationAcceptance;
        confusionClarity.GetComponent<TextMeshProUGUI>().text = "" + emotions.confusionClarity;
        despairJoy.GetComponent<TextMeshProUGUI>().text = "" + emotions.despairJoy;
        shameDignity.GetComponent<TextMeshProUGUI>().text = "" + emotions.shameDignity;
    }
}
