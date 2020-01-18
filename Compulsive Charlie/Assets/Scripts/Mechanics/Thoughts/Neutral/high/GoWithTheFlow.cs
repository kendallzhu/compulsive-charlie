using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoWithTheFlow : Thought
{
    void Awake()
    {
        name = "Go With The Flow";
        descriptionText = "Ride the wave";
        isUnlocked = true;
        energyCost = 2;
        maxJumpPower = 1;
        emotionType = EmotionType.None;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetMaxValue() <= 10)
        {
            return 1;
        }
        return 0;
    }
}