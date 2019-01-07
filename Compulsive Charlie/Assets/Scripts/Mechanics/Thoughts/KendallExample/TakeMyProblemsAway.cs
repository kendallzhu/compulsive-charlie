using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMyProblemsAway : Thought
{
    void Awake()
    {
        name = "Take My Problems Away";
        descriptionText = "give up responsibility";
        isUnlocked = true;
        // always available
        minEmotions = new EmotionState(int.MinValue);
        maxEmotions = new EmotionState(int.MaxValue);
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetTotal() < 0)
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

    // how this thought modifies jump power when active
    public override float JumpBonus(float power)
    {
        return power * .5f;
    }
}
