using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ahhhhh : HighEmotionThought
{
    void Awake()
    {
        name = "Ahhhhh";
        descriptionText = "Frantic scramble!!!";
        isUnlocked = true;
        energyCost = 4;
        jumpPower = 1;
        emotionType = EmotionType.anxiety;
    }
}