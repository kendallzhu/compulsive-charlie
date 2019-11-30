using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakdown : Activity
{
    void Awake()
    {
        name = "Breakdown";
        descriptionText = "overwhelming meltdown of hopelessness";
        heightRating = 0;
        emotionEffect = new EmotionState(0, 0, 0);
        isUnlocked = true;
        isBreakdown = true;
        song = new Heartbeat(EmotionType.despair).song;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        EmotionState e = runState.emotions;
        if (e.GetDominantEmotion() == EmotionType.despair && e.despair >= 10)
        {
            return 1;
        }
        return 0;
    }
}
