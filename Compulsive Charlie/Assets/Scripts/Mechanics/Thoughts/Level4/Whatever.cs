using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whatever : Thought
{
    void Awake()
    {
        name = "Whatever";
        descriptionText = "A reasonable response to frustration";
        isUnlocked = true;
        energyLevel = 4;
        jumpPower = 2;
        invisibleEmotions = new List<string> { };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness("frustration");
    }
}