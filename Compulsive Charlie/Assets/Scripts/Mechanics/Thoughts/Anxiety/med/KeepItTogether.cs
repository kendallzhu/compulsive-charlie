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
        energyCost = 10;
        jumpPower = 4;
        emotionType = EmotionType.anxiety;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (value >= 10 && value <= 20)
        {
            return 1;
        }
        return 0;
    }
}