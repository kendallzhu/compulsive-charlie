using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transcendence : Thought
{
    void Awake()
    {
        name = "Transcendence";
        descriptionText = "No words to describe";
        isUnlocked = true;
        energyLevel = 10;
        jumpPower = 9;
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