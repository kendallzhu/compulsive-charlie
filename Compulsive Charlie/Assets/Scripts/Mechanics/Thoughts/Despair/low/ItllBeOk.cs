using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItllBeOk : LowEmotionThought
{
    void Awake()
    {
        name = "I just hope things will be ok";
        descriptionText = "Don't despair";
        isUnlocked = true;
        energyCost = 3;
        maxJumpPower = 1;
        emotionType = EmotionType.despair;
    }
}