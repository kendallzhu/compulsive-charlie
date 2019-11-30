using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicAttack : Activity
{
    void Awake()
    {
        name = "Panic Attack";
        descriptionText = "overwhelming suffocating anxiety";
        heightRating = 0;
        emotionEffect = new EmotionState(0, 0, 0);
        isUnlocked = true;
        isBreakdown = true;
        song = new Heartbeat(EmotionType.anxiety).song;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        EmotionState e = runState.emotions;
        if (e.GetDominantEmotion() == EmotionType.anxiety && e.anxiety >= 10)
        {
            return 1;
        }
        return 0;
    }
}
