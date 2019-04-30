using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImABurden : Thought
{
    void Awake()
    {
        name = "I'm a Burden";
        descriptionText = "People probably wish I was gone";
        isUnlocked = true;
        energyLevel = 3;
        jumpPower = 1;
        invisibleEmotions = new List<EmotionType> { EmotionType.despair };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.despair;
        if (value >= 15)
        {
            return 1;
        }
        return 0;
    }
}