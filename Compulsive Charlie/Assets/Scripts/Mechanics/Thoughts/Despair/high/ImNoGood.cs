using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImNoGood : Thought
{
    void Awake()
    {
        name = "I'm No Good";
        descriptionText = "I feel useless";
        isUnlocked = true;
        energyLevel = 7;
        jumpPower = 3;
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