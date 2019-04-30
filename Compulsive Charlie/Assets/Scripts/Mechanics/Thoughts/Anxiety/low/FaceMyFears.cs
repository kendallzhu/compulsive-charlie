using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMyFears : Thought
{
    void Awake()
    {
        name = "Face My Fears";
        descriptionText = "What's the worst that could happen anyway?";
        isUnlocked = true;
        energyLevel = 10;
        jumpPower = 7;
        invisibleEmotions = new List<EmotionType> { EmotionType.anxiety };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (value >= 5 && value <= 15)
        {
            return 1;
        }
        return 0;
    }
}