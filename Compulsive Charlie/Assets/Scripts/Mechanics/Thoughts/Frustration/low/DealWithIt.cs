using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWithIt : LowEmotionThought
{
    void Awake()
    {
        name = "Deal With It";
        descriptionText = "Suck it up, get over it";
        isUnlocked = true;
        energyCost = 6;
        jumpPower = 2;
        emotionType = EmotionType.frustration;
    }
}