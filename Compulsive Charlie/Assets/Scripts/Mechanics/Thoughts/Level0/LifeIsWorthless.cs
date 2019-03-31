using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIsWorthless : Thought
{
    void Awake()
    {
        name = "Life is Worthless";
        descriptionText = "Feels honest, but mostly delusional. +++Despair";
        isUnlocked = true;
        energyLevel = 0;
        jumpPower = 0;
        invisibleEmotions = new List<EmotionType> { EmotionType.despair };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.despair);
    }
}