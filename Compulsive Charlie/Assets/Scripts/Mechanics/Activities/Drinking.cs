using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drinking : Activity
{
    void Awake()
    {
        name = "Drinking";
        descriptionText = "problem and solution";
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.Extremeness() > 0 || runState.timeSteps > 8)
        {
            return 1;
        }
        return 0;
    }
}
