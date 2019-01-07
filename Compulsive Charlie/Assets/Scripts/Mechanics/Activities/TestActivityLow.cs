using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestActivityLow : Activity
{
    // Use this for initialization
    void Start()
    {
        name = "Watching Youtube";
        descriptionText = "my head hurts";
        isUnlocked = true;
        associatedThoughts = new List<Thought>();
        // always available
        minEmotions = new EmotionState(int.MinValue);
        maxEmotions = new EmotionState(int.MaxValue);
        repeatProbability = 1f;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return 1;
    }

    // raw height change platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        return -3;
    }

    // how this activity modifies run state when rhythm is hit
    public override void RhythmEffect(RunState runState)
    {
        Debug.Log("Test Activity Low Rhythm");
        return;
    }
}
