using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsUnfair : Thought
{
    void Awake()
    {
        name = "This is Unfair";
        descriptionText = "I don't deserve this.";
        isUnlocked = true;
        energyLevel = 4;
        jumpPower = 3;
        invisibleEmotions = new List<EmotionType> { EmotionType.frustration };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (value >= 10 && value <= 20)
        {
            return 1;
        }
        return 0;
    }
}