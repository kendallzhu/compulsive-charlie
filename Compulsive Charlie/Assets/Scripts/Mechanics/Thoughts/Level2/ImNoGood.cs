using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImNoGood : Thought
{
    void Awake()
    {
        name = "I'm No Good";
        descriptionText = "Strangely comforting, but careful not to neglect the void inside";
        isUnlocked = true;
        energyLevel = 2;
        jumpPower = 2;
        invisibleEmotions = new List<EmotionType> { EmotionType.despair };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness(EmotionType.despair);
    }
}