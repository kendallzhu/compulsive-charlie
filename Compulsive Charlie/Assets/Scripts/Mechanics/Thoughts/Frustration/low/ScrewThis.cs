using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewThis : Thought
{
    void Awake()
    {
        name = "Screw This";
        descriptionText = "hmph.";
        isUnlocked = true;
        energyCost = 0;
        jumpPower = 0;
        emotionType = EmotionType.frustration;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (runState.emotions.GetDominantEmotion() == emotionType && value >= 5 && value <= 15)
        {
            return 1;
        }
        return 0;
    }
}