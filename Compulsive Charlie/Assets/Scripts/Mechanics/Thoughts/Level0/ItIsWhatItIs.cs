using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItIsWhatItIs : Thought
{
    void Awake()
    {
        name = "It is what it is";
        descriptionText = "Accepting reality";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = 0;
        invisibleEmotions = new List<string> { };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return 1;
    }
}