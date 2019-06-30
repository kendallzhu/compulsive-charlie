using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overcome : Thought
{
    void Awake()
    {
        name = "Overcome";
        descriptionText = "Small things ain't stopping me";
        isUnlocked = true;
        energyCost = 10;
        jumpPower = 5;
        emotionType = EmotionType.frustration;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (value >= 5 && value <= 15)
        {
            return 1;
        }
        return 0;
    }
}