﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewThis : Thought
{
    void Awake()
    {
        name = "Screw This";
        descriptionText = "hmph.";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = 1;
        invisibleEmotions = new List<EmotionType> { EmotionType.frustration };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (value >= 10 && value <= 20)
        {
            return 1;
        }
        return 0;
    }
}