using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisCantBeHappening : HighEmotionThought
{
    void Awake()
    {
        name = "*This Can't Be Happening*";
        descriptionText = "This is ridiculous!";
        isUnlocked = true;
        energyCost = 0;
        minJumpPower = -1;
        maxJumpPower = 0;
        emotionType = EmotionType.frustration;
    }
}