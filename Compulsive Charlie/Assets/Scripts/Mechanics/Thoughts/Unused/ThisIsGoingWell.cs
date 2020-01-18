using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsGoingWell : Thought
{
    void Awake()
    {
        name = "This Is Going Well";
        descriptionText = "Exciting, but may mask fears of failure";
        isUnlocked = false;
        energyCost = 6;
        maxJumpPower = 6;
        emotionType = EmotionType.anxiety;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.anxiety);
    }
}