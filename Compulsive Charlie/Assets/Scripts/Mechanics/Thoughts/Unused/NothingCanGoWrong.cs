using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothingCanGoWrong : Thought
{
    void Awake()
    {
        name = "Nothing Can Go Wrong";
        descriptionText = "Empowering, but might lose touch with feelings of danger";
        isUnlocked = false;
        energyCost = 8;
        maxJumpPower = 8;
        emotionType = EmotionType.anxiety;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.anxiety);
    }
}