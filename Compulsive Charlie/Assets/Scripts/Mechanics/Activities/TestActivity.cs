using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestActivity : Activity
{
    void Awake()
    {
        name = "Develop Game";
        descriptionText = "ooh, maybe he'll edit me";
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

    // height of associated platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        return 5;
    }

    // how this activity modifies run state when rhythm is hit
    public override void RhythmEffect(RunState runState)
    {
        Debug.Log("Test Activity Rhythm");
        // test - reduce anxiety
        if (runState.emotions.anxietyTrust < 0)
        {
            runState.emotions.anxietyTrust += 1;
        }
        return;
    }
}
