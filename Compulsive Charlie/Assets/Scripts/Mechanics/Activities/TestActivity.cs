﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestActivity : Activity
{
    // Use this for initialization
    void Start()
    {
        name = "Test Activity";
        descriptionText = "testing is great";
        isUnlocked = true;
        associatedThoughts = new List<Thought>();
        // todo: emotion thresholds thing
        minEmotions = new EmotionState(int.MinValue);
        maxEmotions = new EmotionState(int.MaxValue);
    }

    // whether this activity is available, given state of run
    public override bool IsAvailable(RunState runState)
    {
        return true;
    }

    // height of associated platform if it comes after given run state
    public override int PlatformHeight(RunState runState)
    {
        return runState.CurrentScore() + 5;
    }

    // length of associated platform if it comes after given run state
    public override int PlatformLength(RunState runState)
    {
        return 10 + runState.energy / 2;
    }

    // how this activity modifies run state when rhythm is hit
    public override void RhythmEffect(RunState runState)
    {
        return;
    }
}