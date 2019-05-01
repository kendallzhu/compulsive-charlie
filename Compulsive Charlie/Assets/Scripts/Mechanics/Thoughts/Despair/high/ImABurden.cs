using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImABurden : Thought
{
    void Awake()
    {
        name = "I'm a Burden";
        descriptionText = "People probably wish I was gone (+ despair)";
        isUnlocked = true;
        energyLevel = 7;
        jumpPower = 3;
        invisibleEmotions = new List<EmotionType> { EmotionType.despair };
    }

    public override void CustomAcceptEffect(RunState runState)
    {
        runState.emotions.Add(EmotionType.despair, 3);
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