using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBed : Activity
{
    void Awake()
    {
        name = "Go To Bed";
        descriptionText = "it's all over";
        emotionNotes = new EmotionState(1, 1, 1);
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.timeSteps > 9)
        {
            return 1;
        }
        return 0;
    }
}
