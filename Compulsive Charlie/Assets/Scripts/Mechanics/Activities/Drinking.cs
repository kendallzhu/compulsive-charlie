using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drinking : Activity
{
    void Awake()
    {
        name = "Drinking";
        descriptionText = "the problem or solution?";
        heightRating = -3;
        song = MumenRider.song;
        tempoIncrement = .2f;
        emotionEffect = new EmotionState(8, 4, 4);
        suppressedEmotions.Add(EmotionType.despair);
        suppressedEmotions.Add(EmotionType.frustration);
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int availability = 1;
        availability += runState.emotions.Extremeness(EmotionType.despair);
        availability += runState.emotions.Extremeness(EmotionType.frustration);
        return availability;
    }
}
