using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorldsAgainstMe : HighEmotionThought
{
    void Awake()
    {
        name = "The World's Against Me";
        descriptionText = "I don't deserve this.";
        isUnlocked = true;
        energyCost = 4;
        jumpPower = 1;
        emotionType = EmotionType.frustration;
    }
}