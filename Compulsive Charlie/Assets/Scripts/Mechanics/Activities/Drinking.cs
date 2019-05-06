using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drinking : Activity
{
    void Awake()
    {
        name = "Drinking";
        descriptionText = "problem and solution";
        heightRating = -4;
        emotionNotes = new EmotionState(0, 0, 1);
        emotionEffect = new EmotionState(0, 0, 3);
        rhythmPattern = new List<int> { 1, 2, 7 };
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.Extremeness() > 1 || runState.timeSteps > 8)
        {
            return 3;
        }
        return 1;
    }

    public override void Effect(RunState runState)
    {
        runState.emotions.Add(EmotionType.despair, 3);
        return;
    }
}
