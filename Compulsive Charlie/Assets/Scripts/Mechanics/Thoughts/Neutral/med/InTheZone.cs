using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTheZone : Thought
{
    void Awake()
    {
        name = "In The Zone";
        descriptionText = "No distracting thoughts";
        isUnlocked = true;
        energyLevel = 10;
        jumpPower = 9;
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