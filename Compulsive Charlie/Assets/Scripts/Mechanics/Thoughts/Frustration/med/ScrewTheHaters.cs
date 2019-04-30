using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewTheHaters : Thought
{
    void Awake()
    {
        name = "Screw The Haters";
        descriptionText = "I'll prove them wrong";
        isUnlocked = true;
        energyLevel = 10;
        jumpPower = 6;
        invisibleEmotions = new List<EmotionType> { EmotionType.frustration };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.frustration;
        if (value >= 10 && value <= 20)
        {
            return 1;
        }
        return 0;
    }
}