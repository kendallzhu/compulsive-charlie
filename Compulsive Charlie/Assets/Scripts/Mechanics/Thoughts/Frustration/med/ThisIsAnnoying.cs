using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsAnnoying : Thought
{
    void Awake()
    {
        name = "This Is Annoying";
        descriptionText = "Cringe...";
        isUnlocked = true;
        energyCost = 6;
        jumpPower = 3;
        emotionType = EmotionType.frustration;
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