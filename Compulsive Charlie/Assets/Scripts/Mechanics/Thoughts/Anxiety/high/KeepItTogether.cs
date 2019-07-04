using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepItTogether : Thought
{
    void Awake()
    {
        name = "Keep It Together";
        descriptionText = "Just gotta hold on...";
        isUnlocked = true;
        energyCost = 8;
        jumpPower = 2;
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