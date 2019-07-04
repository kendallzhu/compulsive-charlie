using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProveThemWrong : Thought
{
    void Awake()
    {
        name = "Prove Them Wrong";
        descriptionText = "Screw the haters.";
        isUnlocked = true;
        energyCost = 12;
        jumpPower = 3;
        emotionType = EmotionType.frustration;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (runState.emotions.GetDominantEmotion() == emotionType && value >= 10)
        {
            return 1;
        }
        return 0;
    }
}