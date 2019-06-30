﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItllBeOk : Thought
{
    void Awake()
    {
        name = "It'll Be Ok";
        descriptionText = "Don't despair";
        isUnlocked = true;
        energyCost = 0;
        jumpPower = 2;
        emotionType = EmotionType.despair;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.despair;
        if (value >= 5 && value <= 15)
        {
            return 1;
        }
        return 0;
    }
}