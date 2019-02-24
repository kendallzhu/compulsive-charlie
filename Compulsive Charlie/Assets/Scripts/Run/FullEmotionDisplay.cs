using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FullEmotionDisplay : MonoBehaviour {
    public RunManager runManager;
    public Transform anxiety;
    public Transform frustration;
    public Transform despair;

    public float maxEmotion = 20f;
    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        // get references to and configure emotion displays
        anxiety = gameObject.transform.Find("anxiety");
        anxiety.Find("Filler").GetComponent<Image>().type = Image.Type.Filled;
        anxiety.Find("Filler").GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;
        frustration = gameObject.transform.Find("frustration");
        frustration.Find("Filler").GetComponent<Image>().type = Image.Type.Filled;
        frustration.Find("Filler").GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;
        despair = gameObject.transform.Find("despair");
        despair.Find("Filler").GetComponent<Image>().type = Image.Type.Filled;
        despair.Find("Filler").GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;
    }

    // keep display up to date
    void Update () {
        RunState runState = runManager.runState;
        EmotionState emotions = runState.emotions;
        // set the data for each emotion axis
        anxiety.Find("Text").GetComponent<TextMeshProUGUI>().text = "" + emotions.anxiety;
        despair.Find("Text").GetComponent<TextMeshProUGUI>().text = "" + emotions.despair;
        frustration.Find("Text").GetComponent<TextMeshProUGUI>().text = "" + emotions.frustration;
        // set the bottle fills
        anxiety.Find("Filler").GetComponent<Image>().fillAmount = (float)runState.emotions.anxiety / maxEmotion;
        frustration.Find("Filler").GetComponent<Image>().fillAmount = (float)runState.emotions.frustration / maxEmotion;
        despair.Find("Filler").GetComponent<Image>().fillAmount = (float)runState.emotions.despair / maxEmotion;

    }
}
