using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise : Activity
{
    void Awake()
    {
        name = "Exercise";
        descriptionText = "get the blood moving";
        heightRating = 0;
        emotionEffect = new EmotionState(0, 0, 6);
        isUnlocked = true;
        song = Hero.song;
        // tempoIncrement = .11f;
    }
}
