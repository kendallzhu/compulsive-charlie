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
        energyLevel = 10;
        jumpPower = 6;
        invisibleEmotions = new List<EmotionType> { EmotionType.despair };
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