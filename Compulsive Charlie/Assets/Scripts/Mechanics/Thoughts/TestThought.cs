﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestThought : Thought
{
    void Awake()
    {
        name = "Test Thought";
        descriptionText = "thinking about testing";
        isUnlocked = true;
        // always available
        minEmotions = new EmotionState(int.MinValue);
        maxEmotions = new EmotionState(int.MaxValue);
    }

    // whether this activity is available, given state of run
    public override bool CustomIsAvailable(RunState runState)
    {
        return true;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        Debug.Log("Test Thought");
        // add anxiety
        runState.emotions.anxietyTrust -= 3;
    }
}
