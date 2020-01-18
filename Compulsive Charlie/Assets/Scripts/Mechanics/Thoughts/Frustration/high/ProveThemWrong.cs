using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProveThemWrong : HighEmotionThought
{
    void Awake()
    {
        name = "Prove Them Wrong";
        descriptionText = "Screw the haters.";
        isUnlocked = true;
        energyCost = 12;
        maxJumpPower = 3;
        emotionType = EmotionType.frustration;
    }
}