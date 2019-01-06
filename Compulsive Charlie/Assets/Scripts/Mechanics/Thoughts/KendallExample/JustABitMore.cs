using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustABitMore : Thought
{
    void Awake()
    {
        name = "Just A Bit More";
        descriptionText = "The next one will solve all your problems";
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
        // add anxiety
        runState.emotions.anxietyTrust -= 3;
    }

    // how this thought modifies probability of last activity being available again
    public override float Repeat(float probOffered)
    {
        // more likely to repeat
        return probOffered + .5f;
    }
}
