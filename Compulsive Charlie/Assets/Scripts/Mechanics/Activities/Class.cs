using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : Activity
{
    void Awake()
    {
        name = "Class";
        descriptionText = "I'm in school?";
        emotionNotes = new EmotionState(1, 1, 4);
        isUnlocked = true;
    }
}
