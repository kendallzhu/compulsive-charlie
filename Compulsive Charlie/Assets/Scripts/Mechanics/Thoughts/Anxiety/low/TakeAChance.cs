using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAChance : Thought
{
    void Awake()
    {
        name = "Take A Chance";
        descriptionText = "What's the worst that can happen";
        isUnlocked = true;
        energyCost = 9;
        jumpPower = 3;
        emotionType = EmotionType.anxiety;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (runState.emotions.GetDominantEmotion() == emotionType && value >= 5 && value <= 15)
        {
            return runState.emotions.Extremeness(EmotionType.anxiety);
        }
        return 0;
    }
}