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
        energyCost = 0;
        jumpPower = -1;
        emotionType = EmotionType.despair;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.despair;
        if (runState.emotions.GetDominantEmotion() == emotionType && value >= 10)
        {
            return 1;
        }
        return 0;
    }
}