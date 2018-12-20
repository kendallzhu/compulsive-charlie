using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class for activity mechanic in game
public abstract class Activity : MonoBehaviour {
    // unique name
    new public string name;
    // TODO: animation(s)

    // changeable parameters
    public bool isUnlocked = false;
    public List<Thought> associatedThoughts;
    Dictionary<string, int[]> availabilityThresholds;

    // whether this activity is available, given state of run
    public abstract bool IsAvailable(RunState runState);

    // height of associated platform if it comes after given run state
    public abstract int PlatformHeight(RunState runState);

    // how this activity modifies run state when rhythm is hit
    public abstract void RhythmEffect(RunState runState);
}
