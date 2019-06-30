using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transcendence : Thought
{
    void Awake()
    {
        name = "Transcendence";
        descriptionText = "No words to describe";
        isUnlocked = true;
        energyCost = 10;
        jumpPower = 4;
        emotionType = EmotionType.None;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetMaxValue() <= 1)
        {
            return 3;
        }
        return 0;
    }
}