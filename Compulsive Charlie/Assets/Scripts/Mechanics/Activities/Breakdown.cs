using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakdown : Activity
{
    void Awake()
    {
        name = "Breakdown";
        descriptionText = "emotional meltdown";
        heightRating = 0;
        emotionNotes = new EmotionState(2, 2, 2);
        emotionEffect = new EmotionState(0, 0, 0);
        rhythmPattern = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // only used if all other default activities are not available (see runManager)
        return 0;
    }

    // height of associated platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        // special - always be the default when available
        return runState.emotions.GetRaiseAmount() + defaultPlatformHeightDiff;
    }
}
