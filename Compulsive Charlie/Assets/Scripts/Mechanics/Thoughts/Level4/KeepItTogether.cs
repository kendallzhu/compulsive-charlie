using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepItTogether : Thought
{
    void Awake()
    {
        name = "Keep It Together";
        descriptionText = "Encouraging, but may cover up feelings of stress";
        isUnlocked = true;
        energyLevel = 4;
        jumpPower = 4;
        invisibleEmotions = new List<string> { "anxiety" };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness("anxiety");
    }
}