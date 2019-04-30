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
        energyLevel = 4;
        jumpPower = 5;
        invisibleEmotions = new List<EmotionType> { };
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