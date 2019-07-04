using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGiveUp : HighEmotionThought
{
    void Awake()
    {
        name = "I Give Up";
        descriptionText = "taking the L";
        isUnlocked = true;
        energyCost = 0;
        jumpPower = -1;
        emotionType = EmotionType.despair;
    }
}