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

    // fog sprites
    public List<Sprite> fogSprites;

    private RunManager runManager;

    // Start is called before the first frame update
    void Start()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        Debug.Assert(fogSprites.Count > 0 && fogSprites[0] != null);
    }

    // Update is called once per frame
    void Update()
    {
        RunState runState = runManager.runState;
        EmotionState e = runState.emotions;
        // rain if sad
        tileRain.SetActive(e.Extremeness(EmotionType.despair) > 2);
        // lighning if anxious
        tileLightning.SetActive(e.Extremeness(EmotionType.anxiety) > 2);
        // change fogginess based on total level
        int i = e.GetSum();
        while (i > fogSprites.Count || fogSprites[i] == null)
        {
            i--;
        }
        tileBase.GetComponent<SpriteRenderer>().sprite = fogSprites[i];
    }
}
