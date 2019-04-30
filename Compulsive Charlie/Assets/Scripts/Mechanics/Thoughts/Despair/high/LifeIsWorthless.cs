using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIsWorthless : Thought
{
    void Awake()
    {
        name = "Life is Worthless";
        descriptionText = "I wish I wasn't born";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = 0;
        invisibleEmotions = new List<EmotionType> { EmotionType.despair };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.despair;
        if (value >= 15)
        {
            return 1;
        }
        return 0;
    }
}