using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlsChill : Thought
{
    void Awake()
    {
        name = "PlsChill";
        descriptionText = "...";
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
        runState.emotions.Equilibrate(new EmotionState(0), .1f);
    }
}
