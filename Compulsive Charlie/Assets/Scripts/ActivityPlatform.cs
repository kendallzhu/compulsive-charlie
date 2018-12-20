using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityPlatform : MonoBehaviour {
    public Activity activity;
    public int height;

    // prefabs
    public GameObject platformPrefab;

    public ActivityPlatform(Activity activity, RunState runState)
    {
        height = activity.PlatformHeight(runState);
        // TODO: actually set the transform x and y vars to place platform
    }
}
