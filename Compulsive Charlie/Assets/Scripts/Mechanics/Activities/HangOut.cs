using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangOut : Activity
{
    void Awake()
    {
        name = "Hang Out";
        descriptionText = "Talk to someone";
        heightRating = 1;
        emotionEffect = new EmotionState(10, 6, 6);
        isUnlocked = true;
        song = WakeUpGetOutThere.song;
        tempoIncrement = .2f;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // for now, only when scheduled
        return 0;
    }
}