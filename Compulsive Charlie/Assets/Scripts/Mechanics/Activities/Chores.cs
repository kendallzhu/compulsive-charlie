using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chores : Activity
{
    void Awake()
    {
        name = "Chores";
        descriptionText = "less mess";
        heightRating = 1;
        emotionEffect = new EmotionState(6, 6, 6);
        isUnlocked = true;
        song = ReadyFreddy.song;
        tempoIncrement = .16f;
    }
}
