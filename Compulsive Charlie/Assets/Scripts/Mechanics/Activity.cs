using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Parent class for activity mechanic in game
public abstract class Activity : MonoBehaviour {
    // unique name
    new public string name;
    public string descriptionText; // these are actually supposed to be informative for the real game
    public string infoText; // for full info
    // TODO: animation(s)

    // changeable parameters
    public bool isUnlocked = false;
    public List<Thought> associatedThoughts;
    public float repeatProbability = 1f; // probablility it's offered after just doing it
    // activity is unavailable if any emotion is (< min) or (> max)
    public EmotionState minEmotions;
    public EmotionState maxEmotions;

    // (weighted) availability specific to activity, given state of run
    public abstract int CustomAvailability(RunState runState);

    // (weighted) availability of activity, given state of run
    public int Availability(RunState runState)
    {
        // check that it's unlocked
        if (!isUnlocked)
        {
            return 0;
        }
        // check emotion thresholds
        if (!runState.emotions.Within(minEmotions, maxEmotions))
        {
            return 0;
        }
        return CustomAvailability(runState);
    }

    // (specific to activity)
    // raw height change of platform from previous platform given run state
    public abstract int HeightRating(RunState runState);

    // height of associated platform if it comes after given run state
    public int PlatformHeight(RunState runState)
    {
        int diff = HeightRating(runState);
        int score = runState.CurrentScore();
        // for high scores, differentials get scaled down
        if (score > 0)
        {
            if (diff > 0)
            {
                diff /= (score + 10) / 10;
            }
            else if (diff < 0)
            {
                diff *= (score + 10) / 10; // TODO: This gets extreme - other ideas?
            }
        }
        // for negative scores, differentials get scaled up
        // for high scores, differentials get scaled down
        if (score < 0)
        {
            if (diff < 0)
            {
                diff /= (score + 10) / 10;
            }
            else if (diff > 0)
            {
                diff *= (score + 10) / 10; // TODO: This gets extreme - other ideas?
            }
        }
        return score + diff;
    }

    // how this activity modifies run state when rhythm is hit
    public abstract void RhythmEffect(RunState runState);

    // TODO: should activities have effects? - i.e. energy cost
}
