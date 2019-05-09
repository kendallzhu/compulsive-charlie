using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHateEverything : Thought
{
    void Awake()
    {
        name = "I Hate Everything";
        descriptionText = "I'd burn it all down";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = -1;
        invisibleEmotions = new List<EmotionType> { EmotionType.frustration };
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