using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UhOh : Thought
{
    void Awake()
    {
        name = "Uh Oh";
        descriptionText = "Yikes";
        isUnlocked = true;
        energyCost = 4;
        jumpPower = 2;
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