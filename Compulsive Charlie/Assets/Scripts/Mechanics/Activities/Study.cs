using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study : Activity
{
    void Awake()
    {
        name = "Study";
        descriptionText = "learning and burning";
        heightRating = 3;
        emotionNotes = new EmotionState(1, 1, 0);
        emotionEffect = new EmotionState(4, 4, 0);
        rhythmPattern = new List<int> { 1, 4, 5, 8 };
        isUnlocked = true;
    }
}
