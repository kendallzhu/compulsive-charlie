﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceIt : Thought
{
    void Awake()
    {
        name = "Face It";
        descriptionText = "be brave";
        isUnlocked = true;
        energyCost = 5;
        jumpPower = 6;
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