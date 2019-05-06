using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicAttack : Activity
{
    void Awake()
    {
        name = "Panic Attack";
        descriptionText = "overwhelming suffocating anxiety";
        heightRating = 0;
        emotionNotes = new EmotionState(6, 0, 0);
        emotionEffect = new EmotionState(0, 0, 0);
        rhythmPattern = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        EmotionState e = runState.emotions;
        if (e.GetDominantEmotion() == EmotionType.anxiety && e.Extremeness() > 3)
        {
            return 1;
        }
        return 0;
    }

    // height of associated platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        // special - always be the default when available
        return runState.emotions.GetRaiseAmount() + defaultPlatformHeightDiff;
    }
}
