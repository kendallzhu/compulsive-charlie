using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTheZone : Thought
{
    void Awake()
    {
        name = "In The Zone";
        descriptionText = "Pure focus";
        isUnlocked = true;
        energyCost = 3;
        jumpPower = 3;
        emotionType = EmotionType.None;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetMaxValue() <= 5)
        {
            return 1;
        }
        return 0;
    }
}