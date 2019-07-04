using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whatever : LowEmotionThought
{
    void Awake()
    {
        name = "Whatever";
        descriptionText = "Not gonna let it get to me";
        isUnlocked = true;
        energyCost = 3;
        jumpPower = 1;
        emotionType = EmotionType.frustration;
    }
}