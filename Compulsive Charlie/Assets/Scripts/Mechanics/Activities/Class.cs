using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : Activity
{
    void Awake()
    {
        name = "Class";
        descriptionText = "I'm in school?";
        emotionNotes = new EmotionState(1, 1, 1);
        emotionEffect = new EmotionState(2, 1, 2);
        isUnlocked = true;
    }
}
