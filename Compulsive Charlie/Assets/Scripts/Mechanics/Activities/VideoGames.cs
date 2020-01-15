using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoGames : Activity
{
    void Awake()
    {
        name = "Video Games";
        descriptionText = "...";
        heightRating = -1;
        emotionEffect = new EmotionState(4, 8, 4);
        suppressedEmotions.Add(EmotionType.anxiety);
        suppressedEmotions.Add(EmotionType.despair);
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int availability = 1;
        availability += runState.emotions.Extremeness(EmotionType.despair);
        availability += runState.emotions.Extremeness(EmotionType.anxiety);
        return availability;
    }

    public override void Effect(RunState runState)
    {
        runState.emotions.Add(EmotionType.despair, 1);
        return;
    }
}
