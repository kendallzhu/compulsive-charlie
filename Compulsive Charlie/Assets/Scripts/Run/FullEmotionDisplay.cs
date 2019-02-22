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
        Transform anxiety = gameObject.transform.Find("anxiety");
        Transform frustration = gameObject.transform.Find("frustration");
        Transform despair = gameObject.transform.Find("despair");
        anxiety.Find("Text").GetComponent<TextMeshProUGUI>().text = "" + emotions.anxiety;
        frustration.Find("Text").GetComponent<TextMeshProUGUI>().text = "" + emotions.frustration;
        despair.Find("Text").GetComponent<TextMeshProUGUI>().text = "" + emotions.despair;
    }
}
