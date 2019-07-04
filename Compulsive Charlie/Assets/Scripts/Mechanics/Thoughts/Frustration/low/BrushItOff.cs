using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushItOff : LowEmotionThought
{
    void Awake()
    {
        name = "Brush It Off";
        descriptionText = "Can't let this hold me back";
        isUnlocked = true;
        energyCost = 9;
        jumpPower = 3;
        emotionType = EmotionType.frustration;
    }
}