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
        emotionEffect = new EmotionState(2, 0, 6);
        isUnlocked = true;
        song = Luma.song;
        tempoIncrement = .11f;
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
