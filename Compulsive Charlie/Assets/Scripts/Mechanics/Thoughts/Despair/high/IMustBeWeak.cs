using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMustBeWeak : Thought
{
    void Awake()
    {
        name = "I Must Be Weak";
        descriptionText = "Otherwise, how would I have ended up like this?";
        isUnlocked = true;
        energyCost = 5;
        jumpPower = 2;
        emotionType = EmotionType.despair;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.despair;
        if (value >= 15)
        {
            return 1;
        }
        return 0;
    }
}