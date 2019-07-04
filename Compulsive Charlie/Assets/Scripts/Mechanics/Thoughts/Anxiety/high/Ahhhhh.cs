using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ahhhhh : Thought
{
    void Awake()
    {
        name = "Ahhhhh";
        descriptionText = "Frantic scramble!!!";
        isUnlocked = true;
        energyCost = 4;
        jumpPower = 1;
        emotionType = EmotionType.anxiety;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (runState.emotions.GetDominantEmotion() == emotionType && value >= 10)
        {
            return runState.emotions.Extremeness(EmotionType.anxiety);
        }
        return 0;
    }
}