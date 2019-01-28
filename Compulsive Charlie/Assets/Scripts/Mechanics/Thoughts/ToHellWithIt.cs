using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToHellWithIt : Thought
{
    void Awake()
    {
        name = "To Hell With It";
        descriptionText = "I don't care anymore";
        isUnlocked = true;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // TODO: convert threshold to variable for upgrading
        if (runState.emotions.Extremeness() >= 1)
        {
            return 1;
        }
        return 0;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        runState.jumpPower = 0;
    }

    // how this thought modifies jump power when active
    public override float JumpBonus(float power)
    {
        return 0f;
    }
}
