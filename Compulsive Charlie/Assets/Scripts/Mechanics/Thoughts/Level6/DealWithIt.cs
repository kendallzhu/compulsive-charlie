using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWithIt : Thought
{
    void Awake()
    {
        name = "Deal With It";
        descriptionText = "A wholesome approach to overcome frustration";
        isUnlocked = true;
        energyLevel = 6;
        jumpPower = 4;
        invisibleEmotions = new List<EmotionType> {};
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.frustration);
    }
}