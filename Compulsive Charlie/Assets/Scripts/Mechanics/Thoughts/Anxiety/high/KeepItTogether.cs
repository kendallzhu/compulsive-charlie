using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepItTogether : HighEmotionThought
{
    void Awake()
    {
        name = "Keep It Together Charlie!!";
        descriptionText = "Just gotta hold on...";
        isUnlocked = true;
        energyCost = 8;
        maxJumpPower = 2;
        emotionType = EmotionType.anxiety;
    }
}