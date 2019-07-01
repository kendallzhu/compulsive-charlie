using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisCantBeHappening : Thought
{
    void Awake()
    {
        name = "This Can't Be Happening";
        descriptionText = "This is ridiculous!";
        isUnlocked = true;
        energyCost = 0;
        jumpPower = -1;
        emotionType = EmotionType.frustration;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (value >= 10)
        {
            return 1;
        }
        return 0;
    }
}