using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWithIt : Thought
{
    void Awake()
    {
        name = "Deal With It";
        descriptionText = "overcome";
        isUnlocked = true;
        energyCost = 6;
        jumpPower = 5;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetDominantEmotion() == "frustration")
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