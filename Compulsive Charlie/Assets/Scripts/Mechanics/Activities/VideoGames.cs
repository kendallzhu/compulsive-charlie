using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoGames : Activity
{
    void Awake()
    {
        name = "Video Games";
        descriptionText = "...";
        emotionNotes = new EmotionState(0, 1, 0);
        emotionEffect = new EmotionState(0, 1, 1);
        rhythmPattern = new List<int> { 1, 4, 6 };
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetDominantEmotion() == "frustration")
        {
            return 1;
        }
        return 0;
    }

    public override void Effect(RunState runState)
    {
        runState.emotions.Add("despair", 1);
        return;
    }
}
