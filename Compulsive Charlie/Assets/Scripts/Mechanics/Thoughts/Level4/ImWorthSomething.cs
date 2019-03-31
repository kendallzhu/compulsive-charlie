using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImWorthSomething : Thought
{
    void Awake()
    {
        name = "I'm Worth Something";
        descriptionText = "Encouraging, but may cover up feelings of insecurity";
        isUnlocked = true;
        energyLevel = 4;
        jumpPower = 4;
        invisibleEmotions = new List<EmotionType> { EmotionType.despair };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.despair);
    }
}