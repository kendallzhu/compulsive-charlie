using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class used for instantiating a single instance of an activity (platform during a run)
public class ActivityPlatform : MonoBehaviour {
    public RunManager runManager;
    public Activity activity;

    public int x;
    public int y;
    public int length;
    public bool explored = false;

    private int GapSize(int ydiff)
    {
        if (ydiff < 0)
        {
            return 0;
        }
        return 2;
        // x gap ~ height change for smooth jump
        // return System.Math.Max(0, ydiff - 1);
    }

    // correctly position platform based on current state
    public void Initialize(Activity activity, RunManager manager)
    {
        runManager = manager;
        RunState runState = manager.runState;
        // set the platform at the proper position
        // height specified by activity
        y = activity.PlatformHeight(runState);
        // x to the right of current platform, if there is one
        x = GapSize(y);
        ActivityPlatform current = runState.CurrentActivityPlatform();
        if (current != null)
        {
            int endX = current.x + current.length;
            x = endX + GapSize(y - current.y);
        }
        gameObject.transform.position = new Vector2(x, y);

        // scale the prefab to the proper length
        // (this will work as long as prefab is a unit cube with default scale)
        length = activity.PlatformLength(runState);
        gameObject.transform.localScale = new Vector3(length, .3f, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if Charlie arrives on this platform we trigger updates
        if (other.name == "Charlie" && !explored)
        {
            explored = true;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            // Debug.Log(x);
            // other.transform.position = new Vector2(x + 1, y);
            runManager.AdvanceTimeStep(this);
        }
    }
}
