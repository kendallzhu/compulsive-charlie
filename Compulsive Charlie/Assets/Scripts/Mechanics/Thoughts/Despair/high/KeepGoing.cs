using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepGoing : HighEmotionThought
{
    void Awake()
    {
        name = "Keep Going";
        descriptionText = "Push Through";
        isUnlocked = true;
        energyCost = 8;
        jumpPower = 2;
        emotionType = EmotionType.despair;
    }
}