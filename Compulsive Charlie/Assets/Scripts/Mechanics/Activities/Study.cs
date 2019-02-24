using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study : Activity
{
    void Awake()
    {
        name = "Study";
        descriptionText = "learning and burning";
        emotionNotes = new EmotionState(1, 1, 1);
        emotionEffect = new EmotionState(4, 1, 1);
        isUnlocked = true;
    }
}
