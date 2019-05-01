using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetsDoThis : Thought
{
    void Awake()
    {
        name = "Let's Do This";
        descriptionText = "I'm on fire - what more do I need?";
        isUnlocked = true;
        energyLevel = 10;
        jumpPower = 6;
        invisibleEmotions = new List<EmotionType> { };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetMaxValue() <= 10)
        {
            return 1;
        }
        return 0;
    }
}