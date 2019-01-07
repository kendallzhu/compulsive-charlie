using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingBreak : Activity
{
    void Awake()
    {
        name = "Taking a Break";
        descriptionText = "wow";
        isUnlocked = true;
        associatedThoughts = new List<Thought>
        {
            Object.FindObjectOfType<PlsChill>()

        };
        // always available
        minEmotions = new EmotionState(int.MinValue);
        maxEmotions = new EmotionState(int.MaxValue);
        repeatProbability = .4f;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return 1;
    }

    // height of associated platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        return 0;
    }

    // how this activity modifies run state when rhythm is hit
    public override void RhythmEffect(RunState runState)
    {
        if (Random.value < .2)
        {
            runState.energy += 1;
        }
    }
}
