using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepGoing : Thought
{
    void Awake()
    {
        name = "Keep Going";
        descriptionText = "stay strong";
        isUnlocked = true;
        energyCost = 6;
        jumpPower = 6;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetDominantEmotion() == "despair")
        {
            return 1;
        }
        return 0;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        return;
    }
}