using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stillness : Thought
{
    void Awake()
    {
        name = "Stillness";
        descriptionText = "-";
        isUnlocked = true;
        energyCost = 0;
        jumpPower = -1;
        emotionType = EmotionType.None;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetMaxValue() <= 1)
        {
            return 1;
        }
        return 0;
    }
}