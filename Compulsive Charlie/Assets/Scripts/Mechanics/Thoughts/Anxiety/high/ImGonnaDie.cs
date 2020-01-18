using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImGonnaDie : HighEmotionThought
{
    void Awake()
    {
        name = "I'm Gonna Die";
        descriptionText = "****";
        isUnlocked = true;
        energyCost = 0;
        minJumpPower = -1;
        maxJumpPower = 0;
        emotionType = EmotionType.anxiety;
    }
}