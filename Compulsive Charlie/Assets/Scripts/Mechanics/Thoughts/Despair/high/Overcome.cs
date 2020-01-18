using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overcome : HighEmotionThought
{
    void Awake()
    {
        name = "Overcome";
        descriptionText = "Striving onward";
        isUnlocked = true;
        energyCost = 12;
        maxJumpPower = 3;
        emotionType = EmotionType.despair;
    }
}