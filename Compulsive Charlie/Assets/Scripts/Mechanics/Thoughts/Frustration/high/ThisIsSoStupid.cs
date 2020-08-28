using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsSoStupid : HighEmotionThought
{
    void Awake()
    {
        name = "I Don't Have Time For This Crap!!";
        descriptionText = "Disgusting (+ frustration)";
        isUnlocked = true;
        energyCost = 8;
        maxJumpPower = 2;
        emotionType = EmotionType.frustration;
    }
}