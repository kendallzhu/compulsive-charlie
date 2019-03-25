using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothingCanGoWrong : Thought
{
    void Awake()
    {
        name = "Nothing Can Go Wrong";
        descriptionText = "Empowering, but might lose touch with feelings of danger";
        isUnlocked = true;
        energyLevel = 8;
        jumpPower = 8;
        invisibleEmotions = new List<string> { "anxiety" };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness("anxiety");
    }
}