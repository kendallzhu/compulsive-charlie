using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Parent class for activity mechanic in game
public abstract class Activity : MonoBehaviour {
    // unique name
    new public string name;
    public string descriptionText; // these are actually supposed to be informative for the real game
    // TODO: animation(s)

    // changeable parameters
    public bool isUnlocked = false;
    public List<Thought> associatedThoughts;
    public float repeatProbability = 1f; // probablility it's offered after just doing it
    // activity is unavailable if any emotion is (< min) or (> max)
    public EmotionState minEmotions;
    public EmotionState maxEmotions;

    // availability check specific to activity, given state of run
    public abstract bool CustomIsAvailable(RunState runState);

    // whether this activity is available, given state of run
    public bool IsAvailable(RunState runState)
    {
        // check that it's unlocked
        if (!isUnlocked)
        {
            return false;
        }
        // check emotion thresholds
        if (!runState.emotions.Within(minEmotions, maxEmotions))
        {
            return false;
        }
        return CustomIsAvailable(runState);
    }

    // (specific to activity)
    // raw height change of platform from previous platform given run state
    public abstract int HeightRating(RunState runState);

    // height of associated platform if it comes after given run state
    public int PlatformHeight(RunState runState)
    {
        int diff = HeightRating(runState);
        int score = runState.scoreHistory.Last();
        // TODO: for high scores, differentials get scaled down
        // for negative scores, differentials get scaled up
        return score + diff;
    }

    // how this activity modifies run state when rhythm is hit
    public abstract void RhythmEffect(RunState runState);

    // TODO: should activities have effects? - i.e. energy cost
}
