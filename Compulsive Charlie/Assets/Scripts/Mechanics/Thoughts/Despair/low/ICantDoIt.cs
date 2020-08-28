using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICantDoIt : LowEmotionThought
{
    void Awake()
    {
        name = "Lemme just fill the void";
        descriptionText = "I'm powerless";
        isUnlocked = true;
        energyCost = 0;
        maxJumpPower = 0;
        emotionType = EmotionType.despair;
    }
}