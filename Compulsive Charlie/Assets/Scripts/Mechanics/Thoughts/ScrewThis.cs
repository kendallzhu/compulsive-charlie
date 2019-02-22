using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewThis : Thought
{
    void Awake()
    {
        name = "Screw This";
        descriptionText = "I'm out";
        isUnlocked = true;
        energyCost = 2;
        jumpPower = 0;
    }

    // whether this thought is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int availability = 0;
        if (runState.emotions.GetDominantEmotion() == "frustration")
        {
            availability++;
        }
        availability += runState.emotions.Extremeness("frustration");
        return availability;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        return;
    }
}