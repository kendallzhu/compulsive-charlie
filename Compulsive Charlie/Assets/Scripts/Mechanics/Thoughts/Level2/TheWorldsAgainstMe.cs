using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorldsAgainstMe : Thought
{
    void Awake()
    {
        name = "The World's Against Me";
        descriptionText = "Satisfying to declare, but careful not to go into denial";
        isUnlocked = true;
        energyLevel = 2;
        jumpPower = 2;
        invisibleEmotions = new List<string> { "frustration" };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness("frustration");
    }
}