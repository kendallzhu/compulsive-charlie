using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whatever : LowEmotionThought
{
    void Awake()
    {
        name = "I'll just ignore this crap";
        descriptionText = "Not gonna let it get to me";
        isUnlocked = true;
        energyCost = 3;
        maxJumpPower = 1;
        emotionType = EmotionType.frustration;
    }
}