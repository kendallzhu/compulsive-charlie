using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Parent class for activity mechanic in game
public abstract class Activity : MonoBehaviour {
    // standardized height diff for default platforms
    public const int defaultPlatformHeightDiff = -2;

    // unique name
    new public string name;
    public string descriptionText; // these are actually supposed to be informative for the real game
    public string infoText; // for full info
    // TODO: animation(s)

    // changeable parameters
    public bool isUnlocked = false;
    public List<Thought> associatedThoughts = new List<Thought>();

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
        return CustomAvailability(runState);
    }

    // (specific to activity)
    // raw height change of platform from previous platform given run state
    public abstract int HeightRating(RunState runState);

    // height of associated platform if it comes after given run state
    public int PlatformHeight(RunState runState)
    {
        int diff = HeightRating(runState);
        return runState.height + diff;
    }

    // how this activity modifies run state when rhythm note is hit
    public abstract void HitEffect(RunState runState);

    // how this activity modifies run state when rhythm note is missed
    public abstract void MissEffect(RunState runState);

    // TODO: should activities have effects? - i.e. energy cost
}
