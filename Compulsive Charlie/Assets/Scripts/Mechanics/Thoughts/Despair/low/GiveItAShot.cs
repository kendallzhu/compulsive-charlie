using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItAShot : Thought
{
    void Awake()
    {
        name = "Give it a shot";
        descriptionText = "what's the worst that could happen?";
        isUnlocked = true;
        energyCost = 9;
        jumpPower = 3;
        emotionType = EmotionType.despair;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.despair;
        if (runState.emotions.GetDominantEmotion() == emotionType && value >= 5 && value <= 15)
        {
            return 1;
        }
        return 0;
    }
}