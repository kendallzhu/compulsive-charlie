using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoWithTheFlow : Thought
{
    void Awake()
    {
        name = "Go With the Flow";
        descriptionText = "it's chill";
        isUnlocked = true;
        energyCost = 2;
        jumpPower = 3;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.Extremeness() == 0)
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