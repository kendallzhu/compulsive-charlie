using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGiveUp : Thought
{
    void Awake()
    {
        name = "I Give Up";
        descriptionText = "taking the L";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = 1;
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