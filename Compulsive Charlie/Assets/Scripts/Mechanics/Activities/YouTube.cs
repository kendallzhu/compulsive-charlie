using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouTube : Activity
{
    void Awake()
    {
        name = "YouTube";
        descriptionText = "suggested videos";
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetDominantEmotion() == "anxiety")
        {
            return 1;
        }
        return 0;
    }

    public override void Effect(RunState runState)
    {
        runState.emotions.AddDespair(1);
        return;
    }
}
