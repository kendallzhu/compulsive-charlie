using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImGonnaDie : Thought
{
    void Awake()
    {
        name = "I'm Gonna Die";
        descriptionText = "Feels honest, but missing the real reason?";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = 0;
        invisibleEmotions = new List<string> { "anxiety" };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness("anxiety");
    }
}