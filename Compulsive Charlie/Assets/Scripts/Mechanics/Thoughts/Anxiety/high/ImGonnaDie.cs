using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImGonnaDie : Thought
{
    void Awake()
    {
        name = "I'm Gonna Die";
        descriptionText = "****";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = 0;
        invisibleEmotions = new List<EmotionType> { EmotionType.anxiety };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (value >= 15)
        {
            return 1;
        }
        return 0;
    }
}