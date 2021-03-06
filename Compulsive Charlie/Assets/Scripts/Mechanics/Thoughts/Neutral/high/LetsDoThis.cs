﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetsDoThis : Thought
{
    void Awake()
    {
        name = "Meh";
        descriptionText = "Making it happen";
        isUnlocked = true;
        energyCost = 4;
        maxJumpPower = 2;
        emotionType = EmotionType.None;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetMaxValue() <= 10)
        {
            return 1;
        }
        return 0;
    }
}