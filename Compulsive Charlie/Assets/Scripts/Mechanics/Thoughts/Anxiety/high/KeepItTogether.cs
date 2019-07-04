using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepItTogether : HighEmotionThought
{
    void Awake()
    {
        name = "Keep It Together";
        descriptionText = "Just gotta hold on...";
        isUnlocked = true;
        energyCost = 8;
        jumpPower = 2;
        emotionType = EmotionType.anxiety;
    }
}