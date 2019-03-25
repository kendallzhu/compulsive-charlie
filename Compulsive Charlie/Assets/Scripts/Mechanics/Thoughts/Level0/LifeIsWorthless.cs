using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIsWorthless : Thought
{
    void Awake()
    {
        name = "Life is Worthless";
        descriptionText = "Feels honest, but missing the real reason?";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = 0;
        invisibleEmotions = new List<string> { "despair" };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness("despair");
    }
}