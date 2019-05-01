using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Parent class for activity mechanic in game
public abstract class Activity : MonoBehaviour {
    // standardized height diff for default (lowest) platform
    public const int defaultPlatformHeightDiff = -6;

    // unique name
    new public string name;
    public string descriptionText; // these are actually supposed to be informative for the real game
    public string infoText; // for full info
    // TODO: animation(s)

    // changeable parameters
    public int heightRating = 0;
    public bool isUnlocked = false;
    public EmotionState emotionNotes = new EmotionState(0, 0, 0);
    public EmotionState emotionEffect = new EmotionState(0, 0, 0);
    public List<Thought> associatedThoughts = new List<Thought>();
    public List<int> rhythmPattern = new List<int> { 0, 1, 2, 3, 5, 6 };

    private void Start()
    {
        // for debugging/checks
        Debug.Log(name + " hash: " + Animator.StringToHash(name));
    }

    // (weighted) availability specific to activity, given state of run
    public virtual int CustomAvailability(RunState runState)
    {
        return 1;
    }

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

    // (specific to activity - can customize)
    // raw height change of platform from previous platform given run state
    public virtual int HeightRating(RunState runState)
    {
        // for activites with emotions, difficulty depends on emotions of player
        // DEPRECATED - move current platform based on emotions instead
        /*float emotionCharge = emotionNotes.DotProduct(runState.emotions) / 5f;
        if (emotionCharge > 0)
        {
            return (int)emotionCharge;
        }
        return  defaultPlatformHeightDiff;*/
        return heightRating;
    }

    // height of associated platform if it comes after given run state
    public int PlatformHeight(RunState runState)
    {
        int diff = HeightRating(runState);
        return runState.height + diff;
    }

    // activity specific effects
    public virtual void Effect(RunState runState)
    {
        runState.emotions.Add(emotionEffect);
        return;
    }
}
