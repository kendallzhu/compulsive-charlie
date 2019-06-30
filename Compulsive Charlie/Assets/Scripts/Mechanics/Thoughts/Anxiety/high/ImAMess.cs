using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImAMess : Thought
{
    void Awake()
    {
        name = "I'm a Mess";
        descriptionText = "Out of control (+ anxiety)";
        isUnlocked = true;
        energyCost = 3;
        jumpPower = 3;
        emotionType = EmotionType.anxiety;
    }

    public override void CustomAcceptEffect(RunState runState)
    {
        runState.emotions.Add(EmotionType.anxiety, 3);
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.anxiety;
        if (value >= 15)
        {
            return 1;
        }
        return 0;
    }
}