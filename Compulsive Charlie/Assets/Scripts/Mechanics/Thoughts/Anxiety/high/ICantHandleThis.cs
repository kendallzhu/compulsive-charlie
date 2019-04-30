using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICantHandleThis : Thought
{
    void Awake()
    {
        name = "I Can't Handle This";
        descriptionText = "It's just too much";
        isUnlocked = true;
        energyLevel = 5;
        jumpPower = 2;
        invisibleEmotions = new List<EmotionType> { EmotionType.anxiety };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (value >= 15)
        {
            return 1;
        }
        return 0;
    }
}