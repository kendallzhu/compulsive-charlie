using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nothing : Thought
{
    void Awake()
    {
        name = "Nothing";
        descriptionText = "really, nothing?";
        isUnlocked = true;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // TODO: only available if all other default activities are not available
        return 1;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        return;
    }
}
