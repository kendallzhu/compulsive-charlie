using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relax : LowEmotionThought
{
    void Awake()
    {
        name = "Relax";
        descriptionText = "Take a deep breath";
        isUnlocked = true;
        energyCost = 6;
        maxJumpPower = 2;
        emotionType = EmotionType.anxiety;
    }
}