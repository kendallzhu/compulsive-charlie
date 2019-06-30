using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItsWorthThePain : Thought
{
    void Awake()
    {
        name = "Its Worth The Pain";
        descriptionText = "Pushing through";
        isUnlocked = true;
        energyCost = 10;
        jumpPower = 4;
        emotionType = EmotionType.despair;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.despair;
        if (value >= 10 && value <= 20)
        {
            return 1;
        }
        return 0;
    }
}