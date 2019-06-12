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
        emotionNotes = new EmotionState(1, 1, 0);
        emotionEffect = new EmotionState(1, 3, 1);
        isUnlocked = true;
    }
}
