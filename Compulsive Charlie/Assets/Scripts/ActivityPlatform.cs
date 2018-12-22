using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class used for instantiating a single instance of an activity (platform during a run)
public class ActivityPlatform : MonoBehaviour {
    public Activity activity;

    public void Initialize(Activity activity, RunState runState)
    {
        int x = 0; // TODO: look at platform length or something?
        int y = activity.PlatformHeight(runState);

        gameObject.transform.position = new Vector3(x, y, 0);
        // set the transform x and y vars to place platform

    }
}
