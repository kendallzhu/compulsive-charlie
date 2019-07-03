using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakdown : Activity
{
    void Awake()
    {
        name = "Breakdown";
        descriptionText = "overwhelming meltdown of hopelessness";
        heightRating = 0;
        emotionEffect = new EmotionState(0, 0, 0);
        isUnlocked = true;
        isBreakdown = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        EmotionState e = runState.emotions;
        if (e.GetDominantEmotion() == EmotionType.despair && e.Extremeness() > 3)
        {
            return 1;
        }
        return 0;
    }
}
