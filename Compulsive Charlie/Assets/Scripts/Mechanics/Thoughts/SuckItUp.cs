using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckItUp : Thought
{
    void Awake()
    {
        name = "Suck It Up";
        descriptionText = "can't let it stop u";
        isUnlocked = true;
        energyCost = 5;
        jumpPower = 6;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetDominantEmotion() == "frustration")
        {
            return 1;
        }
        return 0;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        return;
    }
}