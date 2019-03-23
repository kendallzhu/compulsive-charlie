using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepIn : Activity
{
    void Awake() // haha
    {
        name = "Sleep In";
        descriptionText = "ugh";
        emotionNotes = new EmotionState(0, 0, 0);
        emotionEffect = new EmotionState(0, 0, 1);
        rhythmPattern = new List<int> { 4, 6};
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.timeSteps <= 1 || runState.TimeSinceLast(this) == 0)
        {
            return 1;
        }
        return 0;
    }
}
