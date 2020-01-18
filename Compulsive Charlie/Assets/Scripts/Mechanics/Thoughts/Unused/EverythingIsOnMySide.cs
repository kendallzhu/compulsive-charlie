using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EverythingIsOnMySide : Thought
{
    void Awake()
    {
        name = "Everything Is On My Side";
        descriptionText = "Empowering, but might lose touch with negative feelings";
        isUnlocked = false;
        energyCost = 8;
        maxJumpPower = 8;
        emotionType = EmotionType.frustration;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.frustration);
    }
}