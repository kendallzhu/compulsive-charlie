using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relax : LowEmotionThought
{
    void Awake()
    {
        name = "It's not the end of the world, Charlie!";
        descriptionText = "Take a deep breath";
        isUnlocked = true;
        energyCost = 6;
        maxJumpPower = 2;
        emotionType = EmotionType.anxiety;
    }
}