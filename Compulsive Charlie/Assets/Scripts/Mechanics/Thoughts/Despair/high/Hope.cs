using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hope : Thought
{
    void Awake()
    {
        name = "Hope";
        descriptionText = "Preserve the light";
        isUnlocked = true;
        energyCost = 4;
        jumpPower = 1;
        emotionType = EmotionType.despair;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.despair;
        if (value >= 10)
        {
            return 1;
        }
        return 0;
    }
}