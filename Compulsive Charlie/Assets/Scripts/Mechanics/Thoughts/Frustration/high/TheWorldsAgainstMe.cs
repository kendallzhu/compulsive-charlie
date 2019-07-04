using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorldsAgainstMe : Thought
{
    void Awake()
    {
        name = "The World's Against Me";
        descriptionText = "I don't deserve this.";
        isUnlocked = true;
        energyCost = 4;
        jumpPower = 1;
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