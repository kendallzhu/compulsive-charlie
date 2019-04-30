using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangInThere : Thought
{
    void Awake()
    {
        name = "Hang In There";
        descriptionText = "Stay Strong";
        isUnlocked = true;
        energyLevel = 5;
        jumpPower = 5;
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