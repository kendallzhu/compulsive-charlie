using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsSoStupid : HighEmotionThought
{
    void Awake()
    {
        name = "This Is So Stupid";
        descriptionText = "Disgusting (+ frustration)";
        isUnlocked = true;
        energyCost = 8;
        jumpPower = 2;
        emotionType = EmotionType.frustration;
    }
}