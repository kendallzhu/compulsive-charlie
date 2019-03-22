using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UhOh : Thought
{
    void Awake()
    {
        name = "Uh Oh";
        descriptionText = "look away";
        isUnlocked = true;
        energyCost = 2;
        jumpPower = 0;
    }

    // whether this thought is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int availability = 0;
        if (runState.emotions.GetDominantEmotion() == "anxiety")
        {
            availability++;
        }
        // availability += runState.emotions.Extremeness("anxiety");
        return availability;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        return;
    }
}