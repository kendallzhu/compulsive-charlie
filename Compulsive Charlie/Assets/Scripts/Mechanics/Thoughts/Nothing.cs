using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nothing : Thought
{
    void Awake()
    {
        name = "Nothing";
        descriptionText = "really, nothing?";
        isUnlocked = true;
        energyCost = 0;
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
