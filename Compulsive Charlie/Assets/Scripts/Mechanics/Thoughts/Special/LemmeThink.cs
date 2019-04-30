using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmeThink : Thought
{
    void Awake()
    {
        name = "Lemme Think";
        descriptionText = "Anxiously consider the worst possible consequences";
        isUnlocked = false;
        energyLevel = 3;
        jumpPower = 2;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return 1;
    }

    public override void CustomAcceptEffect(RunState runState)
    {
        runState.emotions.Add(EmotionType.anxiety, 3);
        return;
    }

    public override void CustomRejectEffect(RunState runState)
    {
        // runState.emotions.Add(EmotionType.anxiety, 3);
        return;
    }
}