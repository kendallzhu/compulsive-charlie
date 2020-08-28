using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAChance : LowEmotionThought
{
    void Awake()
    {
        name = "I Gotta Take My Chances!!";
        descriptionText = "What's the worst that can happen";
        isUnlocked = true;
        energyCost = 9;
        maxJumpPower = 3; 
        emotionType = EmotionType.anxiety;
    }
}