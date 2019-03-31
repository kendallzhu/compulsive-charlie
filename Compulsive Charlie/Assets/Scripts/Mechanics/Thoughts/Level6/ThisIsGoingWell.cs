using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsGoingWell : Thought
{
    void Awake()
    {
        name = "This Is Going Well";
        descriptionText = "Exciting, but may mask fears of failure";
        isUnlocked = true;
        energyLevel = 6;
        jumpPower = 6;
        invisibleEmotions = new List<EmotionType> { EmotionType.anxiety };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.anxiety);
    }
}