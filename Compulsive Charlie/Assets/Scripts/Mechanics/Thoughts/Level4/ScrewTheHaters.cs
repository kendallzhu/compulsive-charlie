using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewTheHaters : Thought
{
    void Awake()
    {
        name = "Screw The Haters";
        descriptionText = "Encouraging, but may cover up feelings of resentment";
        isUnlocked = true;
        energyLevel = 4;
        jumpPower = 4;
        invisibleEmotions = new List<string> { "frustration" };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness("frustration");
    }
}