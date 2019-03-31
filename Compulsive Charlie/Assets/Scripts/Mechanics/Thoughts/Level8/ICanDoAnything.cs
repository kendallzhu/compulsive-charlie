using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICanDoAnything : Thought
{
    void Awake()
    {
        name = "I Can Do Anything...";
        descriptionText = "Empowering, but might lose touch with feelings of vulnerability";
        isUnlocked = true;
        energyLevel = 8;
        jumpPower = 8;
        invisibleEmotions = new List<EmotionType> { EmotionType.despair };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.despair);
    }
}