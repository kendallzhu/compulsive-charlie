﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ahhhhh : Thought
{
    void Awake()
    {
        name = "Ahhhhh";
        descriptionText = "Frantic scramble!!!";
        isUnlocked = true;
        energyLevel = 7;
        jumpPower = 3;
        invisibleEmotions = new List<EmotionType> { EmotionType.anxiety };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (value >= 15)
        {
            return 1;
        }
        return 0;
    }
}