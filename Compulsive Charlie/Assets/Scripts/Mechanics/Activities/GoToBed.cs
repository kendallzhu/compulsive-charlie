using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBed : Activity
{
    void Awake()
    {
        name = "Go To Bed";
        descriptionText = "it's all over";
        heightRating = 0;
        emotionNotes = new EmotionState(1, 0, 1);
        emotionEffect = new EmotionState(1, 0, 1);
        rhythmPattern = new List<int> { 1, 5, 7 };
        isUnlocked = true;
    }

    public override void Effect(RunState runState)
    {
        runState.done = true;
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

    // make it easier to go to bed the later it is
    public override int HeightRating(RunState runState)
    {
        int lateness = System.Math.Max(0, runState.timeSteps - 10);
        return base.HeightRating(runState) - lateness;
    }
}
