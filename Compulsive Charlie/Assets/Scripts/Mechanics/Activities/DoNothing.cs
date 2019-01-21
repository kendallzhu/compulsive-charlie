﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNothing : Activity
{
    void Awake()
    {
        name = "Do Nothing";
        descriptionText = "wait - actually nothing?";
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // TODO: only available if all other default activities are not available
        return 1;
    }

    // height of associated platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        return -2;
    }

    // how this activity modifies run state when rhythm is hit
    public override void HitEffect(RunState runState)
    {
        return;
    }

    // how this activity modifies run state when rhythm is missed
    public override void MissEffect(RunState runState)
    {
        return;
    }
}