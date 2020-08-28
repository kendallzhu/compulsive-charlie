using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItEasy : LowEmotionThought
{
    void Awake()
    {
        name = "I'll just play it safe";
        descriptionText = "No Need to Panic";
        isUnlocked = true;
        energyCost = 3;
        maxJumpPower = 1; 
        emotionType = EmotionType.anxiety;
    }
}