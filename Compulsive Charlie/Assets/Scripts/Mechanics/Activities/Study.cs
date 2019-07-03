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
        emotionEffect = new EmotionState(4, 4, 0);
        isUnlocked = true;
    }
}
