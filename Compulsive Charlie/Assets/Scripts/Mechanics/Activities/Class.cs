using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : Activity
{
    void Awake()
    {
        name = "Class";
        descriptionText = "I'm in school?";
        heightRating = 1;
        emotionEffect = new EmotionState(6, 2, 6);
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // for now, only when scheduled
        return 0;
    }
}
