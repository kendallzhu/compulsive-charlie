using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWithIt : LowEmotionThought
{
    void Awake()
    {
        name = "Whatever, I'll just brush it off!";
        descriptionText = "Suck it up, get over it";
        isUnlocked = true;
        energyCost = 6;
        maxJumpPower = 2;
        emotionType = EmotionType.frustration;
    }
}