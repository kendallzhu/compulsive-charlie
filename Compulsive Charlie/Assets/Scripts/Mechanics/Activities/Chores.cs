using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chores : Activity
{
    void Awake()
    {
        name = "Chores";
        descriptionText = "less mess";
        emotionNotes = new EmotionState(0, 4, 0);
        isUnlocked = true;
    }
}
