using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoMyBest : Thought
{
    void Awake()
    {
        name = "Let's Roll!";
        descriptionText = "100% effort";
        isUnlocked = true;
        energyCost = 6;
        maxJumpPower = 3;
        emotionType = EmotionType.None;
    }

    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetMaxValue() <= 10)
        {
            return 1;
        }
        return 0;
    }
}