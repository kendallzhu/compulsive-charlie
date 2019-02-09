using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepIn : Activity
{
    void Awake()
    {
        name = "Sleep In";
        descriptionText = "ugh";
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.timeSteps <= 1 || runState.TimeSinceLast(this) <= 1)
        {
            return 1;
        }
        return 0;
    }
}
