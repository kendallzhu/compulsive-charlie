using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class for activity mechanic in game
public abstract class Activity : MonoBehaviour {
    // unique name
    new public string name;
    public string descriptionText;
    // TODO: animation(s)

    // changeable parameters
    public bool isUnlocked = false;
    public List<Thought> associatedThoughts;
    // activity is unavailable if any emotion is (< min) or (> max)
    public EmotionState minEmotions;
    public EmotionState maxEmotions;

    // whether this activity is available, given state of run
    public abstract bool IsAvailable(RunState runState);

    // height of associated platform if it comes after given run state
    public abstract int PlatformHeight(RunState runState);

    // length of associated platform if it comes after given run state
    public abstract int PlatformLength(RunState runState);

    // how this activity modifies run state when rhythm is hit
    public abstract void RhythmEffect(RunState runState);
}
