using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meh : Thought
{
    void Awake()
    {
        name = "Meh";
        descriptionText = "Don't want to make effort";
        isUnlocked = true;
        energyLevel = 4;
        jumpPower = 3;
        invisibleEmotions = new List<EmotionType> { EmotionType.despair };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.despair;
        if (value >= 10 && value <= 20)
        {
            return 1;
        }
        return 0;
    }
}