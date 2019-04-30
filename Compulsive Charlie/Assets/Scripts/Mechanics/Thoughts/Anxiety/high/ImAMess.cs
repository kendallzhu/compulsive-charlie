using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImAMess : Thought
{
    void Awake()
    {
        name = "I'm a Mess";
        descriptionText = "Out of control";
        isUnlocked = true;
        energyLevel = 3;
        jumpPower = 1;
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