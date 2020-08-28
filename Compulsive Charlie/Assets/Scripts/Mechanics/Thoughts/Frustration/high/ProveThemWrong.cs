using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProveThemWrong : HighEmotionThought
{
    void Awake()
    {
        name = "I Swear I Will Prove The Haters Wrong!!!";
        descriptionText = "Screw the haters.";
        isUnlocked = true;
        energyCost = 12;
        maxJumpPower = 3;
        emotionType = EmotionType.frustration;
    }
}