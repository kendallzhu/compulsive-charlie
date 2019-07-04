using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItllBeOk : LowEmotionThought
{
    void Awake()
    {
        name = "It'll Be Ok";
        descriptionText = "Don't despair";
        isUnlocked = true;
        energyCost = 3;
        jumpPower = 1;
        emotionType = EmotionType.despair;
    }
}