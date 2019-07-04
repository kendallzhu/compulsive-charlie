using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWithIt : Thought
{
    void Awake()
    {
        name = "Deal With It";
        descriptionText = "Suck it up, get over it";
        isUnlocked = true;
        energyCost = 6;
        jumpPower = 2;
        emotionType = EmotionType.frustration;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (runState.emotions.GetDominantEmotion() == emotionType && value >= 5 && value <= 15)
        {
            return 1;
        }
        return 0;
    }
}