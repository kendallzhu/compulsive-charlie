using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangInThere : LowEmotionThought
{
    void Awake()
    {
        name = "I'll do what I can!";
        descriptionText = "Stay Strong";
        isUnlocked = true;
        energyCost = 6;
        maxJumpPower = 2;
        emotionType = EmotionType.despair;
    }
}