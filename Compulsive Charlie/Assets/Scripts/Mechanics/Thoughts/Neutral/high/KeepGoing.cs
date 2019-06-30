using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepGoing : Thought
{
    void Awake()
    {
        name = "Keep Going";
        descriptionText = "We goin' places";
        isUnlocked = true;
        energyCost = 4;
        jumpPower = 4;
        emotionType = EmotionType.None;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetMaxValue() <= 10)
        {
            return 1;
        }
        return 0;
    }
}