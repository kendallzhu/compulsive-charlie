using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewThis : LowEmotionThought
{
    void Awake()
    {
        name = "Screw This";
        descriptionText = "hmph.";
        isUnlocked = true;
        energyCost = 0;
        jumpPower = 0;
        emotionType = EmotionType.frustration;
    }
}