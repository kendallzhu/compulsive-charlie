﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGiveUp : Thought
{
    void Awake()
    {
        name = "I Give Up";
        descriptionText = "it's hopeless";
        isUnlocked = true;
        energyCost = 2;
        jumpPower = 0;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetDominantEmotion() == "despair")
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