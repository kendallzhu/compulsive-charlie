using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nothing : Thought
{
    void Awake()
    {
        name = "Nothing";
        descriptionText = "";
        isUnlocked = false;
        energyCost = 0;
        maxJumpPower = 1;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return 0;
    }
}
