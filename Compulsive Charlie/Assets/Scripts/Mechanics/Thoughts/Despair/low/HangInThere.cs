using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangInThere : LowEmotionThought
{
    void Awake()
    {
        name = "Hang In There";
        descriptionText = "Stay Strong";
        isUnlocked = true;
        energyCost = 6;
        jumpPower = 2;
        emotionType = EmotionType.despair;
    }
}