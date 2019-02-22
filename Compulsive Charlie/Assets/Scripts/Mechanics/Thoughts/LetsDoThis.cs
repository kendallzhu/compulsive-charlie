using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetsDoThis : Thought
{
    void Awake()
    {
        name = "Let's Do This";
        descriptionText = "leggo";
        isUnlocked = true;
        energyCost = 4;
        jumpPower = 6;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.Extremeness() <= 0)
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