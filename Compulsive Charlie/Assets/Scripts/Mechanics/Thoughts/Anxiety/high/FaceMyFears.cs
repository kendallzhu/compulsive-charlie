using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMyFears : Thought
{
    void Awake()
    {
        name = "Face My Fears";
        descriptionText = "What's the worst that could happen anyway?";
        isUnlocked = true;
        energyCost = 12;
        jumpPower = 3;
        emotionType = EmotionType.anxiety;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (runState.emotions.GetDominantEmotion() == emotionType && value >= 10)
        {
            return 1;
        }
        return 0;
    }
}