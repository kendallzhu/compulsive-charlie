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
        emotionEffect = new EmotionState(2, 2, 2);
        suppressedEmotions.Add(EmotionType.frustration);
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetDominantEmotion() == EmotionType.anxiety)
        {
            return 3;
        }
        return 1;
    }

    public override void Effect(RunState runState)
    {
        runState.emotions.Add(EmotionType.despair, 1);
        return;
    }
}
