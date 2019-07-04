using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hope : HighEmotionThought
{
    void Awake()
    {
        name = "Hope";
        descriptionText = "Preserve the light";
        isUnlocked = true;
        energyCost = 4;
        jumpPower = 1;
        emotionType = EmotionType.despair;
    }
}