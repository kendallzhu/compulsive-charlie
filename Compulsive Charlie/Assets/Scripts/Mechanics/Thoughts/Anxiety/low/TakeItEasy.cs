using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItEasy : Thought
{
    void Awake()
    {
        name = "Take It Easy";
        descriptionText = "No Need to Panic";
        isUnlocked = true;
        energyCost = 3;
        jumpPower = 1;
        emotionType = EmotionType.anxiety;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (runState.emotions.GetDominantEmotion() == emotionType && value >= 5 && value <= 15)
        {
            return 1;
        }
        return 0;
    }
}