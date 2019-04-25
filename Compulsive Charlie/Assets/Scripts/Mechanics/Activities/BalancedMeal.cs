using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancedMeal : Activity
{
    void Awake()
    {
        name = "Balanced Meal";
        descriptionText = "fruits and veggies";
        heightRating = 2;
        emotionNotes = new EmotionState(1, 1, 1);
        emotionEffect = new EmotionState(2, 2, 0);
        rhythmPattern = new List<int> { 2, 4, 6, 8 };
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // only when scheduled
        return 0;
    }
}
