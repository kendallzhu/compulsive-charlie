using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binge : Activity
{
    void Awake()
    {
        name = "Binge";
        descriptionText = "fill the hole with food";
        heightRating = -1;
        emotionEffect = new EmotionState(0, 0, 4);
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetDominantEmotion() == EmotionType.despair)
        {
            return 1;
        }
        Activity balancedMeal = Object.FindObjectOfType<BalancedMeal>();
        int timeSinceEat = System.Math.Min(runState.TimeSinceLast(this), runState.TimeSinceLast(balancedMeal));
        int hunger = System.Math.Max(0, timeSinceEat - 3);
        return hunger;
    }
}
