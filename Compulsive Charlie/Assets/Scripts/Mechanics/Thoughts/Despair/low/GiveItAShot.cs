using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItAShot : LowEmotionThought
{
    void Awake()
    {
        name = "I gotta give it my best shot!";
        descriptionText = "what's the worst that could happen?";
        isUnlocked = true;
        energyCost = 9;
        maxJumpPower = 3;
        emotionType = EmotionType.despair;
    }
}