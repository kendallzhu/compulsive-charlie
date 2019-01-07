﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsGoingSomewhere : Thought
{
    void Awake()
    {
        name = "This is going somewhere";
        descriptionText = "huge, key, spicy";
        isUnlocked = true;
        // always available
        minEmotions = new EmotionState(int.MinValue);
        maxEmotions = new EmotionState(int.MaxValue);
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return 1;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        runState.emotions.frustrationAcceptance += 2;
        runState.emotions.despairJoy += 2;
    }

    // how this thought modifies probability of last activity being available again
    public override float Repeat(float probOffered)
    {
        return probOffered + .5f;
    }
}
