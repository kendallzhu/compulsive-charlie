using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepIn : Activity
{
    void Awake() // haha
    {
        name = "Sleep In";
        descriptionText = "ugh";
        heightRating = -3;
        emotionEffect = new EmotionState(1, 0, 2);
        isUnlocked = true;
        song = Luma.song;
        tempoIncrement = .1f;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.timeSteps <= 1 || runState.TimeSinceLast(this) == 0)
        {
            // dominate when available
            return 10;
        }
        return 0;
    }
}
