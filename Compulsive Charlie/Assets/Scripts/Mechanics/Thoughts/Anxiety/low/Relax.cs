using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relax : Thought
{
    void Awake()
    {
        name = "Relax";
        descriptionText = "Take a deep breath";
        isUnlocked = true;
        energyLevel = 5;
        jumpPower = 5;
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