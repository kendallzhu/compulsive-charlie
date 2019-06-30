using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImScrewed : Thought
{
    void Awake()
    {
        name = "I'm Screwed";
        descriptionText = "It's falling apart";
        isUnlocked = true;
        energyCost = 0;
        jumpPower = 1;
        emotionType = EmotionType.anxiety;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (value >= 10 && value <= 20)
        {
            return 1;
        }
        return 0;
    }
}