using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushItOff : Thought
{
    void Awake()
    {
        name = "Brush It Off";
        descriptionText = "Can't let this hold me back";
        isUnlocked = true;
        energyCost = 9;
        jumpPower = 3;
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