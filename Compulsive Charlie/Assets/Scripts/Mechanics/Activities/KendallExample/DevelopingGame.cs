using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopingGame : Activity
{
    void Awake()
    {
        name = "Developing Game";
        descriptionText = "that's me!";
        isUnlocked = true;
        associatedThoughts = new List<Thought>
        {
            Object.FindObjectOfType<ThisIsGoingNowhere>(),
            Object.FindObjectOfType<ThisMightNotWork>(),

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
        return 3;
    }

    // how this activity modifies run state when rhythm is hit
    public override void RhythmEffect(RunState runState)
    {
        runState.emotions.anxietyTrust += 1;
        runState.emotions.shameDignity += 1;
        runState.emotions.confusionClarity += 1;
        return;
    }
}
