using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INeedToMakeProgress : Thought
{
    void Awake()
    {
        name = "I Need To Make Progress";
        descriptionText = "trynna go places";
        isUnlocked = true;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // TODO: convert threshold to variable for upgrading
        if (runState.emotions.GetDominantEmotion() == "frustration")
        {
            return 1;
        }
        return 0;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        runState.emotions.AddAnxiety(3);
    }

    // how this thought modifies jump power when active
    public override float JumpBonus(float power)
    {
        // TODO: make variable for upgrades
        return power * 1.5f;
    }
}
