using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relax : Thought
{
    void Awake()
    {
        name = "Relax";
        descriptionText = "not end of world";
        isUnlocked = true;
        energyCost = 4;
        jumpPower = 3;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetDominantEmotion() == "anxiety")
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