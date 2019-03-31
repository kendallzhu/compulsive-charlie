using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UhOh : Thought
{
    void Awake()
    {
        name = "Uh Oh";
        descriptionText = "Realistically coping with anxiety";
        isUnlocked = true;
        energyLevel = 2;
        jumpPower = 0;
        invisibleEmotions = new List<EmotionType> { };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.anxiety);
    }
}