using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsGoingNowhere : Thought
{
    void Awake()
    {
        name = "This is going nowhere";
        descriptionText = "might as well give up now";
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
        runState.emotions.frustrationAcceptance -= 2;
        runState.emotions.despairJoy -= 2;
    }

    // how this thought modifies probability of last activity being available again
    public override float Repeat(float probOffered)
    {
        return probOffered - .5f;
    }
}
