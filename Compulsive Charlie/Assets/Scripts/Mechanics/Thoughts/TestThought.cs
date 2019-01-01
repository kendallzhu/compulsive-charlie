using System.Collections;
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
    public override bool IsAvailable(RunState runState)
    {
        return true;
    }

    // how this thought modifies run state when thunk
    public override void Effect(RunState runState)
    {
        Debug.Log("Test Thought");
        // add anxiety, drain 1 energy
        runState.emotions.anxietyTrust -= 3;
        runState.energy = System.Math.Max(0, runState.energy - 1);
        return;
    }

    // how this thought modifies jump power when active
    public override float JumpBonus(float power)
    {
        return power;
    }
}
