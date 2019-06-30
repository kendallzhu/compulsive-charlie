using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorldsAgainstMe : Thought
{
    void Awake()
    {
        name = "The World's Against Me";
        descriptionText = "I can tell everyone hates me";
        isUnlocked = true;
        energyCost = 3;
        jumpPower = 1;
        emotionType = EmotionType.frustration;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (value >= 15)
        {
            return 1;
        }
        return 0;
    }
}