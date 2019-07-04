using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMyFears : HighEmotionThought
{
    void Awake()
    {
        name = "Face My Fears";
        descriptionText = "What's the worst that could happen anyway?";
        isUnlocked = true;
        energyCost = 12;
        jumpPower = 3;
        emotionType = EmotionType.anxiety;
    }
}