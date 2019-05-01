using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peace : Thought
{
    void Awake()
    {
        name = "Peace";
        descriptionText = "I can enjoy most things";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = 4;
        invisibleEmotions = new List<EmotionType> { };
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