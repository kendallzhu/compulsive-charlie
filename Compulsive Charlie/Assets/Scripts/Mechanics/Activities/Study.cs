using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study : Activity
{
    void Awake()
    {
        name = "Study";
        descriptionText = "learning and burning";
        emotionNotes = new EmotionState(6, 1, 1);
        isUnlocked = true;
    }
}
