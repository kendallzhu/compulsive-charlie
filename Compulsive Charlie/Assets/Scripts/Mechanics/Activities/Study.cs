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
        emotionEffect = new EmotionState(8, 8, 2);
        isUnlocked = true;
        song = Hero.song;
    }
}
