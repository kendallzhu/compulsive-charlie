using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsSoStupid : Thought
{
    void Awake()
    {
        name = "This Is So Stupid";
        descriptionText = "Disgusting";
        isUnlocked = true;
        energyLevel = 5;
        jumpPower = 2;
        invisibleEmotions = new List<EmotionType> { EmotionType.frustration };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (value >= 15)
        {
            return 1;
        }
        return 0;
    }
}