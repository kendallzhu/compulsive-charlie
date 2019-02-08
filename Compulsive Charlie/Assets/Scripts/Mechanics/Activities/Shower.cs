using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : Activity
{
    void Awake()
    {
        name = "Shower";
        descriptionText = "pls";
        emotionNotes = new EmotionState(1, 1, 1);
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // probably would be part of schedule anyway this is for if you miss ur first chance
        if (runState.timeSteps > 9)
        {
            return 1;
        }
        return 0;
    }
}
