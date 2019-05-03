using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : Activity
{
    void Awake()
    {
        name = "Class";
        descriptionText = "I'm in school?";
        heightRating = 1;
        emotionNotes = new EmotionState(1, 0, 1);
        emotionEffect = new EmotionState(3, 1, 3);
        rhythmPattern = new List<int> { 1, 3, 4, 6 };
        isUnlocked = true;
    }
}
