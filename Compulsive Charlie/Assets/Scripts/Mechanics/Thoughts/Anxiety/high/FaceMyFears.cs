using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMyFears : HighEmotionThought
{
    void Awake()
    {
        name = "I Will Face My Darkest Fears!!!";
        descriptionText = "What's the worst that could happen anyway?";
        isUnlocked = true;
        energyCost = 12;
        maxJumpPower = 3;
        emotionType = EmotionType.anxiety;
    }
}