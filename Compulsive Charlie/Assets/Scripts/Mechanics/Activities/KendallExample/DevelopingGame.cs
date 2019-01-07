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
        repeatProbability = .7f;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return 1;
    }

    // height of associated platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        return 3;
    }

    // how this activity modifies run state when rhythm is hit
    public override void RhythmEffect(RunState runState)
    {
        // TODO: too much rng?
        if (Random.value < .9)
        {
            runState.emotions.anxietyTrust += 1;
        } else
        {
            runState.emotions.anxietyTrust -= 5;
        }
        if (Random.value < .9)
        {
            runState.emotions.shameDignity += 1;
        } else
        {
            runState.emotions.shameDignity -= 5;
        }
        if (Random.value < .9)
        {
            runState.emotions.confusionClarity += 1;
        } else
        {
            runState.emotions.confusionClarity -= 5;
        }
    }
}
