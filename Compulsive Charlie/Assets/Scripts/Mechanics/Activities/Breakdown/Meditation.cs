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
        emotionEffect = new EmotionState(0, 0, 0);
        isBreakdown = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // only used if all other default activities are not available (see runManager)
        return 0;
    }
}
