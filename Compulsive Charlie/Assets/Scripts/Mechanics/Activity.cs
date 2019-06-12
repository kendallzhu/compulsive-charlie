using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NoteSpec
{
    public int timing;
    public string instrument;
    public string pitch;
    public int angle;

    public NoteSpec (int timing, string pitch, int angle, string instrument = "wood_block")
    {
        this.timing = timing;
        this.instrument = instrument;
        this.pitch = pitch;
        this.angle = angle;
    }
}

// Parent class for activity mechanic in game
public abstract class Activity : MonoBehaviour {
    // standardized height diff for default (lowest) normal platform
    public const int defaultPlatformHeightDiff = -5;
    // hard lower limit for height diff of any platform
    // used for "breakdown" platforms that can be only got to by negative jump power
    public const int breakdownPlatformHeightDiff = -8;

    // unique name
    new public string name;
    public string descriptionText; // these are actually supposed to be informative for the real game
    public string infoText; // for full info
    // TODO: animation(s)

    // changeable parameters
    public bool isBreakdown = false;
    public int heightRating = 0;
    public bool isUnlocked = false;
    public EmotionState emotionNotes = new EmotionState(0, 0, 0);
    public EmotionState emotionEffect = new EmotionState(0, 0, 0);
    public List<Thought> associatedThoughts = new List<Thought>();
    // specs for gameplay notes
    public List<NoteSpec> rhythmPattern = new List<NoteSpec> {
        new NoteSpec(1, "C", 0),
        new NoteSpec(2, "D", 2),
        new NoteSpec(3, "E", 4),
        new NoteSpec(4, "F", 6),
        new NoteSpec(5, "G", 8),
    };

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

    // helper function for classifying an activity
    public bool IsDefault(RunState runState)
    {
        // default activities can be normal activities as well - it depends on the runState
        ActivityPlatform current = runState.CurrentActivityPlatform();
        int h = current ? current.y : 0;
        int ydiff = PlatformHeight(runState) - h;
        // any activity that is below threshold ydiff qualifies
        return ydiff <= defaultPlatformHeightDiff && !isBreakdown;
    }

    // (weighted) availability of activity, given state of run
    public int Availability(RunState runState)
    {
        // check that it's unlocked
        if (!isUnlocked)
        {
            return 0;
        }
        // disallow normal activity that would be at or below breakdown height, to avoid weird situations 
        ActivityPlatform current = runState.CurrentActivityPlatform();
        int h = current ? current.y : 0;
        int ydiff = PlatformHeight(runState) - h;
        if (ydiff <= breakdownPlatformHeightDiff && !isBreakdown)
        {
            return 0;
        }

        // don't allow any activities lower than the breakdown
        return CustomAvailability(runState);
    }

    // (specific to activity - can customize)
    // raw height change of platform from previous platform given run state
    public virtual int HeightRating(RunState runState)
    {
        // breakdown activities are special! - they always have the same height difference,
        // regardless of how much the current platform shifts up/down
        if (isBreakdown)
        {
            return runState.emotions.GetRaiseAmount() + breakdownPlatformHeightDiff;
        }
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
