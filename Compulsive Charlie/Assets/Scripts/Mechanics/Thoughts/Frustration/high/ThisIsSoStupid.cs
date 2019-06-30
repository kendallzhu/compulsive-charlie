using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsSoStupid : Thought
{
    void Awake()
    {
        name = "This Is So Stupid";
        descriptionText = "Disgusting (+ frustration)";
        isUnlocked = true;
        energyCost = 7;
        jumpPower = 3;
        emotionType = EmotionType.frustration;
    }

    public override void CustomAcceptEffect(RunState runState)
    {
        runState.emotions.Add(EmotionType.frustration, 3);
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (value >= 15)
        {
            return 1;
        }
        return 0;
    }
}