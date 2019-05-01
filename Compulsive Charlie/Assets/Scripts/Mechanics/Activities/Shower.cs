using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : Activity
{
    void Awake()
    {
        name = "Shower";
        descriptionText = "pls";
        heightRating = 0;
        emotionNotes = new EmotionState(0, 1, 0);
        emotionEffect = new EmotionState(0, 0, 0);
        rhythmPattern = new List<int> { 1, 5, 7 };
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // for now, only when scheduled
        return 0;
    }
}
