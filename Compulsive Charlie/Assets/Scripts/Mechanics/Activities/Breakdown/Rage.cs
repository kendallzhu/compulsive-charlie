using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : Activity
{
    void Awake()
    {
        name = "Rage";
        descriptionText = "overwhelming explosion of anger";
        heightRating = 0;
        emotionEffect = new EmotionState(0, 0, 0);
        isUnlocked = true;
        isBreakdown = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        EmotionState e = runState.emotions;
        if (e.GetDominantEmotion() == EmotionType.frustration && e.frustration >= 10)
        {
            return 1;
        }
        return 0;
    }
}
