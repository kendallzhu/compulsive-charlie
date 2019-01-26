using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// class used for instantiating a single instance of an activity (platform during a run)
public class ActivityPlatform : MonoBehaviour {
    public RunManager runManager;
    public Activity activity;
    // constants - TODO: may these ever depend on activity or runState i.e emotion? if so convert to function
    // universal dimensions of all platforms - (design choice to simplify, don't think variable lengths add much)
    private const int jumpPadLength = 3;
    private const float platformThickness = .3f;
    private const int standardGapLength = 2;
    public int platformLength = 12;

    public int x;
    public int y;
    public int length;
    public bool explored = false;
    public bool jumpPadExplored = false;

    // other prefabs
    public GameObject rhythmNotePrefab;

    // calculate horizontal gap for a given platform
    private int GapSize(int ydiff)
    {
        // make only default platforms have gap 0
        if (ydiff <= Activity.defaultPlatformHeightDiff)
        {
            return 0;
        }
        return standardGapLength;
    }

    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    // correctly position platform based on current state
    public void Initialize(Activity _activity)
    {
        activity = _activity;
        RunState runState = runManager.runState;
        // set the platform at the proper position
        // height specified by activity
        y = activity.PlatformHeight(runState);
        // x to the right of current platform, if there is one
        x = GapSize(y);
        length = platformLength;
        ActivityPlatform current = runState.CurrentActivityPlatform();
        if (current != null)
        {
            int endX = current.x + current.length;
            x = endX + GapSize(y - current.y) + jumpPadLength;
        }
        gameObject.transform.position = new Vector2(x, y);

        // scale the transform of the physical platform child to the proper length
        // (this will work as long as prefab is a unit cube with default scale)
        Transform ground = gameObject.transform.Find("Ground");
        ground.localScale = new Vector2(length, platformThickness);
        // scale the fixed length jump pad at the end of the platform
        Transform jumpPad = gameObject.transform.Find("JumpPad");
        jumpPad.position = new Vector2(x + length, y); 
        jumpPad.localScale = new Vector2(jumpPadLength, platformThickness);
    }

    public void StartRhythm()
    {
        if (activity != null)
        {
            // TODO: associate rhythm pattern with activity - use coroutine and list of time intervals?
            // tempo based on energy
            float energy = runManager.runState.energy;
            float tempo = Mathf.Pow(energy/10f, .5f);
            InvokeRepeating("SpawnRhythmNote", .5f, 1f / tempo);
        }
    }

    public void StopRhythm()
    {
        CancelInvoke("SpawnRhythmNote");
    }

    public void SpawnRhythmNote()
    {
        // TODO: varying heights? (parameter, specifying special notes?)
        GameObject rhythmNote = Instantiate(rhythmNotePrefab, new Vector2(x, y + 2.2f), Quaternion.identity);
        rhythmNote.GetComponent<RhythmNote>().Initialize(this);
    }
}
