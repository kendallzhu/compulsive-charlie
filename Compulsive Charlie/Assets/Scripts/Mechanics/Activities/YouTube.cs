using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouTube : Activity
{
    void Awake()
    {
        name = "YouTube";
        descriptionText = "suggested videos";
        heightRating = -3;
        emotionEffect = new EmotionState(4, 4, 8);
        suppressedEmotions.Add(EmotionType.anxiety);
        suppressedEmotions.Add(EmotionType.frustration);
        isUnlocked = true;
        song = Solutions.song;
        tempoIncrement = .20f;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int availability = 1;
        /*if (runState.emotions.Extremeness(EmotionType.anxiety) > 2 ||
            runState.emotions.Extremeness(EmotionType.frustration) > 2)
        {
            return 3;
        }*/
        availability += runState.emotions.Extremeness(EmotionType.anxiety);
        availability += runState.emotions.Extremeness(EmotionType.frustration);
        return 1;
    }

    public override void Effect(RunState runState)
    {
        runState.emotions.Add(EmotionType.despair, 1);
        return;
    }
}
