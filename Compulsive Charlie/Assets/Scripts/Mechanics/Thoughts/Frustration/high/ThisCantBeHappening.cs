using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisCantBeHappening : HighEmotionThought
{
    void Awake()
    {
        name = "This Can't Be Happening";
        descriptionText = "This is ridiculous!";
        isUnlocked = true;
        energyCost = 0;
        jumpPower = -1;
        emotionType = EmotionType.frustration;
    }
}