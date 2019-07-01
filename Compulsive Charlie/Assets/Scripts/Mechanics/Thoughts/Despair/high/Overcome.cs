using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overcome : Thought
{
    void Awake()
    {
        name = "Overcome";
        descriptionText = "Striving onward";
        isUnlocked = true;
        energyCost = 12;
        jumpPower = 3;
        emotionType = EmotionType.despair;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.despair;
        if (value >= 10)
        {
            return 1;
        }
        return 0;
    }
}