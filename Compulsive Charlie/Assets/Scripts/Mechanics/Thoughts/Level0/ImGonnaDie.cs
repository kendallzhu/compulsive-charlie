using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImGonnaDie : Thought
{
    void Awake()
    {
        name = "I'm Gonna Die";
        descriptionText = "Feels honest, but mostly delusional. +++Anxiety";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = 0;
        invisibleEmotions = new List<EmotionType> { EmotionType.anxiety };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.anxiety);
    }
}