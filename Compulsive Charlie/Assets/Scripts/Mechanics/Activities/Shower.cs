using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : Activity
{
    void Awake()
    {
        name = "Shower";
        descriptionText = "pls";
        heightRating = 0;
        emotionEffect = new EmotionState(0, 0, 2);
        isUnlocked = true;
        song = Luma.song;
        tempoIncrement = .11f;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // for now, only when scheduled
        return 0;
    }
}
