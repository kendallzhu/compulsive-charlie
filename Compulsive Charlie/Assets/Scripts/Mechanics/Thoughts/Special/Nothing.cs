﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nothing : Thought
{
    void Awake()
    {
        name = "Nothing";
        descriptionText = "";
        isUnlocked = true;
        energyLevel = 10;
        jumpPower = 9;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.Extremeness() <= 0)
        {
            return 5;
        }
        return 2;
    }

    // how this thought modifies run state when thunk
    public override void CustomAcceptEffect(RunState runState)
    {
        runState.emotions.Equilibrate(.2f);
    }
}