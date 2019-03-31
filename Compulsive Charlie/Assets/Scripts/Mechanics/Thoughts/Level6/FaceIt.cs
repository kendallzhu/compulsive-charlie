using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceIt : Thought
{
    void Awake()
    {
        name = "Face It";
        descriptionText = "A wholesome approach to overcome anxiety";
        isUnlocked = true;
        energyLevel = 6;
        jumpPower = 4;
        invisibleEmotions = new List<EmotionType> { };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.anxiety);
    }
}