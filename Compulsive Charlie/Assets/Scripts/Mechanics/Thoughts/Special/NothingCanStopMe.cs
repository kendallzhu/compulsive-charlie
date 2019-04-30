using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothingCanStopMe : Thought
{
    void Awake()
    {
        name = "Nothing Can Stop Me";
        descriptionText = "Exciting, but may mask feelings of irritation";
        isUnlocked = false;
        energyLevel = 6;
        jumpPower = 6;
        invisibleEmotions = new List<EmotionType> { EmotionType.frustration };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.frustration);
    }
}