using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    // static backgrounds
    public GameObject bgStatic;
    public GameObject staticBase;
    public GameObject staticOverlay;

    // tiled background components
    public GameObject bgTile;
    public GameObject tileBase;
    public GameObject tileRain;
    public GameObject tileLightning;

    private RunManager runManager;

    // Start is called before the first frame update
    void Start()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RunState runState = runManager.runState;
        EmotionState e = runState.emotions;
        // rain if sad
        tileRain.SetActive(e.Extremeness(EmotionType.despair) > 1);
        // lighning if anxious
        tileLightning.SetActive(e.Extremeness(EmotionType.anxiety) > 1);
        // send the emotion level into the tile base
        tileBase.GetComponent<Animator>().SetInteger("emotionTotal", e.GetSum());
    }
}
