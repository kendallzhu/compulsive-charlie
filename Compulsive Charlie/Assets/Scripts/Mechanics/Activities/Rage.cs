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
        emotionNotes = new EmotionState(0, 6, 0);
        emotionEffect = new EmotionState(0, 0, 0);
        rhythmPattern = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        isUnlocked = true;
        isBreakdown = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        EmotionState e = runState.emotions;
        if (e.GetDominantEmotion() == EmotionType.frustration && e.Extremeness() > 3)
        {
            return 1;
        }
        return 0;
    }
}
