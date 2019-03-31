using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICanDoThis : Thought
{
    void Awake()
    {
        name = "I Can Do This";
        descriptionText = "Exciting, but may mask feelings of doubt";
        isUnlocked = true;
        energyLevel = 6;
        jumpPower = 6;
        invisibleEmotions = new List<EmotionType> { EmotionType.despair };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.despair);
    }
}