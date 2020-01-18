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
        energyCost = 6;
        maxJumpPower = 6;
        emotionType = EmotionType.frustration;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.frustration);
    }
}