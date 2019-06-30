using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WTF : Thought
{
    void Awake()
    {
        name = "WTF?!";
        descriptionText = "Are you kidding me?";
        isUnlocked = true;
        energyCost = 10;
        jumpPower = 3;
        emotionType = EmotionType.frustration;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (value >= 15)
        {
            return 1;
        }
        return 0;
    }
}