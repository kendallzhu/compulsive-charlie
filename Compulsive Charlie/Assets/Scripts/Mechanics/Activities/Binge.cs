﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binge : Activity
{
    void Awake()
    {
        name = "Binge";
        descriptionText = "fill the hole with food";
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetDominantEmotion() == "despair")
        {
            return 1;
        }
        Activity balancedMeal = Object.FindObjectOfType<BalancedMeal>();
        int timeSinceEat = System.Math.Min(runState.TimeSinceLast(this), runState.TimeSinceLast(balancedMeal));
        int hunger = System.Math.Max(0, timeSinceEat - 2);
        return hunger;
    }
}
