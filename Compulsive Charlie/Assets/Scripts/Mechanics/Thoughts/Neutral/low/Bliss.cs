using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bliss : Thought
{
    void Awake()
    {
        name = "Bliss";
        descriptionText = "It comes from within";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = 5;
        invisibleEmotions = new List<EmotionType> { };
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