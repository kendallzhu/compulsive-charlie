using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAChance : LowEmotionThought
{
    void Awake()
    {
        name = "Take A Chance";
        descriptionText = "What's the worst that can happen";
        isUnlocked = true;
        energyCost = 9;
        jumpPower = 3;
        emotionType = EmotionType.anxiety;
    }
}