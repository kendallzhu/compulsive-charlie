using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItllBeOk : Thought
{
    void Awake()
    {
        name = "It'll Be Ok";
        descriptionText = "A reasonable response to despair";
        isUnlocked = true;
        energyLevel = 4;
        jumpPower = 2;
        invisibleEmotions = new List<string> { };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness("despair");
    }
}