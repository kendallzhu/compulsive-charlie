using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoWithTheFlow : Thought
{
    void Awake()
    {
        name = "Go With the Flow";
        descriptionText = "Sometimes chilling out is the way to go";
        isUnlocked = true;
        energyLevel = 5;
        jumpPower = 3;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return 1;
    }

    // how this thought modifies run state when thunk
    public override void CustomAcceptEffect(RunState runState)
    {
        runState.emotions.Equilibrate(.1f);
    }
}