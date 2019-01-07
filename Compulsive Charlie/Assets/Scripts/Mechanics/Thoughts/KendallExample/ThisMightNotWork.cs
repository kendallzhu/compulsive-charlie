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
    public override int CustomAvailability(RunState runState)
    {
        return 1;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        if (runState.emotions.confusionClarity > 0)
        {
            runState.emotions.confusionClarity /= 2;
        }
        runState.emotions.confusionClarity -= 2;
        if (runState.emotions.anxietyTrust > 0)
        {
            runState.emotions.anxietyTrust /= 2;
        }
        runState.emotions.anxietyTrust -= 2;
    }
}
