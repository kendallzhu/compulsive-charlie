using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whatever : Thought
{
    void Awake()
    {
        name = "Whatever";
        descriptionText = "moving on";
        isUnlocked = true;
        energyCost = 4;
        jumpPower = 3;
        invisibleEmotions = new List<string> { "frustration" };
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