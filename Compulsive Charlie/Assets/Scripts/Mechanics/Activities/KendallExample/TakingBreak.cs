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
        repeatProbability = .5f;
    }

    // whether this activity is available, given state of run
    public override bool CustomIsAvailable(RunState runState)
    {
        return true;
    }

    // height of associated platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        return 0;
    }

    // how this activity modifies run state when rhythm is hit
    public override void RhythmEffect(RunState runState)
    {
        runState.energy += 1; // TODO: 20% chance?
        return;
    }
}
