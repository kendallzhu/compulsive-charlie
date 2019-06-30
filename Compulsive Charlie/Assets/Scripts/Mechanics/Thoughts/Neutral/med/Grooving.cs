﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grooving : Thought
{
    void Awake()
    {
        name = "Grooving";
        descriptionText = "in sync with life";
        isUnlocked = true;
        energyCost = 5;
        jumpPower = 5;
        emotionType = EmotionType.None;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetMaxValue() <= 5)
        {
            return 1;
        }
        return 0;
    }
}