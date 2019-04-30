using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoMyBest : Thought
{
    void Awake()
    {
        name = "Do My Best";
        descriptionText = "100% = enough";
        isUnlocked = true;
        energyLevel = 6;
        jumpPower = 6;
        invisibleEmotions = new List<EmotionType> { };
    }

    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetMaxValue() <= 10)
        {
            return 1;
        }
        return 0;
    }
}