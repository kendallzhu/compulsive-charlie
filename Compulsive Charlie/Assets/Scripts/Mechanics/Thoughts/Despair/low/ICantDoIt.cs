using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICantDoIt : Thought
{
    void Awake()
    {
        name = "I Can't Do It";
        descriptionText = "I'm powerless";
        isUnlocked = true;
        energyCost = 0;
        jumpPower = 0;
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