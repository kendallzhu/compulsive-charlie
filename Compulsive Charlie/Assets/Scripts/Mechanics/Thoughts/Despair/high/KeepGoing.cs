using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepGoing : Thought
{
    void Awake()
    {
        name = "Keep Going";
        descriptionText = "Push Through";
        isUnlocked = true;
        energyCost = 8;
        jumpPower = 2;
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