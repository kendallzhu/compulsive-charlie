﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGiveUp : Thought
{
    void Awake()
    {
        name = "I Give Up";
        descriptionText = "Realistically coping with despair";
        isUnlocked = true;
        energyLevel = 2;
        jumpPower = 0;
        invisibleEmotions = new List<string> { };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness("despair");
    }
}