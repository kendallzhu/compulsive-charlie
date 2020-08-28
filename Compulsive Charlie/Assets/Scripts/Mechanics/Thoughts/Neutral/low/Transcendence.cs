using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transcendence : Thought
{
    void Awake()
    {
        name = "Free at last";
        descriptionText = "No limits";
        isUnlocked = true;
        energyCost = 0;
        maxJumpPower = 4;
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