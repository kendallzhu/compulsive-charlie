using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisMightNotWork : Thought
{
    void Awake()
    {
        name = "This might not work";
        descriptionText = "guess I'll waver and half-ass it";
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
        runState.emotions.confusionClarity -= 2;
        runState.emotions.anxietyTrust -= 2;
    }
}
