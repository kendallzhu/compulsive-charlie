using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGiveUp : Thought
{
    void Awake()
    {
        name = "I Give Up";
        descriptionText = "it's no use";
        isUnlocked = true;
        energyCost = 2;
        jumpPower = 0;
    }

    // whether this thought is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int availability = 0;
        if (runState.emotions.GetDominantEmotion() == "despair")
        {
            availability++;
        }
        availability += runState.emotions.Extremeness("despair");
        return availability;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        return;
    }
}