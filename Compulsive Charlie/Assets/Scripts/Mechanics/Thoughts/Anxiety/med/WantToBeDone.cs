﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantToBeDone : Thought
{
    void Awake()
    {
        name = "Want To Be Done";
        descriptionText = "Please get this over with...";
        isUnlocked = true;
        energyCost = 6;
        jumpPower = 3;
        emotionType = EmotionType.anxiety;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (value >= 10 && value <= 20)
        {
            return 1;
        }
        return 0;
    }
}