using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICanDoThis : Thought
{
    void Awake()
    {
        name = "I Can Do This";
        descriptionText = "Don't let myself get down";
        isUnlocked = true;
        energyLevel = 10;
        jumpPower = 7;
        invisibleEmotions = new List<EmotionType> { EmotionType.despair };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.despair;
        if (value >= 5 && value <= 15)
        {
            return 1;
        }
        return 0;
    }
}