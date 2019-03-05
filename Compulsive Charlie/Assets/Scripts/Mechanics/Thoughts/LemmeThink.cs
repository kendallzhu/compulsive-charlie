using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmeThink : Thought
{
    void Awake()
    {
        name = "Lemme Think";
        descriptionText = "hmmm";
        isUnlocked = true;
        energyCost = 2;
        jumpPower = 0;
        rethink = true;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        /* if (runState.emotions.GetDominantEmotion() == "anxiety")
        {
            return runState.emotions.Extremeness();
        } */
        return 1;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        return;
    }
}