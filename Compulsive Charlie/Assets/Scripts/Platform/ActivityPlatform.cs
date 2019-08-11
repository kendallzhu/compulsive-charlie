using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// class used for instantiating a single instance of an activity (platform during a run)
public class ActivityPlatform : MonoBehaviour {
    public RunManager runManager;
    public Activity activity;
    // constants
    private const int jumpPadLength = 2;
    private const float platformThickness = .3f;
    private const int standardGapLength = 2;
    private const int platformLength = 24;
    private const float raiseSmooth = 2;
    // set location of the bottom left of the platform
    public int x;
    public int y;
    public int length;
    public bool explored = false;
    public bool jumpPadExplored = false;
    public int bestCombo = 0;
    public int jumpNumber;

    // other prefabs
    public GameObject rhythmNotePrefab;

    // calculate horizontal gap for a given platform
    private int GapSize(int ydiff)
    {
        // make breakdown platforms have gap -3
        if (ydiff <= Activity.breakdownPlatformHeightDiff)
        {
            return -3;
        }
        // make default platforms have gap 0
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

    private void Update()
    {
        // move towards target height
        float newY = Mathf.Lerp(transform.position.y, y, Time.deltaTime * raiseSmooth);
        transform.position = new Vector2(transform.position.x, newY);
    }

    // correctly position platform based on current states
    public void Initialize(Activity _activity, int heightDiff, int jumpNumber)
    {
        activity = _activity;
        RunState runState = runManager.runState;
        this.jumpNumber = jumpNumber;
        // set the platform at the proper position
        // height specified by activity
        y = runState.height + heightDiff;
        // x to the right of current platform, if there is one
        x = GapSize(heightDiff);
        length = platformLength;
        ActivityPlatform current = runState.CurrentActivityPlatform();
        if (current != null)
        {
            int endX = current.x + current.length;
            x = endX + GapSize(y - current.y) + jumpPadLength;
        }
        gameObject.transform.position = new Vector2(x, runState.height);

        // scale the transform of the physical platform child to the proper length
        // (this will work as long as prefab is a unit cube with default scale)
        Transform ground = gameObject.transform.Find("Ground");
        ground.localScale = new Vector2(length, platformThickness);
        // scale the fixed length jump pad at the end of the platform
        Transform jumpPad = gameObject.transform.Find("JumpPad");
        jumpPad.localPosition = new Vector2(length, 0); 
        jumpPad.localScale = new Vector2(jumpPadLength, platformThickness);
    }

    // shifts platform up a specified amount
    public void Raise(int height)
    {
        y += height;
    }
}
