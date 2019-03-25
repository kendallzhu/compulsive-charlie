using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EverythingIsOnMySide : Thought
{
    void Awake()
    {
        name = "Everything Is On My Side";
        descriptionText = "Empowering, but might lose touch with negative feelings";
        isUnlocked = true;
        energyLevel = 8;
        jumpPower = 8;
        invisibleEmotions = new List<string> { "frustration" };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness("frustration");
    }
}