using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushItOff : LowEmotionThought
{
    void Awake()
    {
        name = "I Gotta Push Through The Barriers!!";
        descriptionText = "Can't let this hold me back";
        isUnlocked = true;
        energyCost = 9;
        maxJumpPower = 3;
        emotionType = EmotionType.frustration;
    }
}