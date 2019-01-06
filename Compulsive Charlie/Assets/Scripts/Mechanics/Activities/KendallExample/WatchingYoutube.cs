using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchingYoutube : Activity
{
    void Awake()
    {
        name = "Watching Youtube";
        descriptionText = "something's fishy";
        isUnlocked = true;
        associatedThoughts = new List<Thought>
        {
            Object.FindObjectOfType<JustABitMore>(),
            Object.FindObjectOfType<TakeMyProblemsAway>(),

        };
        // always available
        minEmotions = new EmotionState(int.MinValue);
        maxEmotions = new EmotionState(int.MaxValue);
        repeatProbability = 1f;
    }

    // whether this activity is available, given state of run
    public override bool CustomIsAvailable(RunState runState)
    {
        return true;
    }

    // height of associated platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        return -2;
    }

    // how this activity modifies run state when rhythm is hit
    public override void RhythmEffect(RunState runState)
    {
        if (runState.emotions.despairJoy < 0)
        {
            runState.emotions.despairJoy += 1;
        }
        if (runState.emotions.fearCuriosity < 0)
        {
            runState.emotions.fearCuriosity += 1;
        }
        if (runState.emotions.cravingContentment < 0)
        {
            runState.emotions.cravingContentment += 1;
        }
        return;
    }
}
