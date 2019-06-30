using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICantKeepFailing : Thought
{
    void Awake()
    {
        name = "I Can't Keep Failing";
        descriptionText = "I'm digging myself into a hole";
        isUnlocked = true;
        energyCost = 10;
        jumpPower = 3;
        emotionType = EmotionType.despair;
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