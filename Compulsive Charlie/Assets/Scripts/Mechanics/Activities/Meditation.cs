using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meditation : Activity
{
    void Awake()
    {
        name = "Meditation";
        descriptionText = "exploring the inside";
        heightRating = 0;
        emotionNotes = new EmotionState(2, 2, 0);
        emotionEffect = new EmotionState(0, 0, 0);
        rhythmPattern = new List<int> { }; // {1, 2, 3, 4, 5, 6, 7, 8};
        for (int i = 0; i < 40; i++)
        {
            rhythmPattern.Add(i);
        }
        isBreakdown = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // only used if all other default activities are not available (see runManager)
        return 0;
    }
}
