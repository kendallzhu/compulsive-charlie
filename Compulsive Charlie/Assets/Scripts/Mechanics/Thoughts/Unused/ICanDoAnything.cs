using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICanDoAnything : Thought
{
    void Awake()
    {
        name = "I Can Do Anything...";
        descriptionText = "Empowering, but might lose touch with feelings of vulnerability";
        isUnlocked = false;
        energyCost = 8;
        maxJumpPower = 8;
        emotionType = EmotionType.despair;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.despair);
    }
}