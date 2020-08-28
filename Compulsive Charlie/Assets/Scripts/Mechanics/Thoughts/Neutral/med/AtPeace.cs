using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtPeace : Thought
{
    void Awake()
    {
        name = "It is what it is";
        descriptionText = "I can enjoy most things";
        isUnlocked = true;
        energyCost = 1;
        maxJumpPower = 1;
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