using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Parent class for activity mechanic in game
public abstract class Activity : MonoBehaviour {
    // standardized height diff for default (lowest) normal platform
    public const int defaultPlatformHeightDiff = -2;
    // hard lower limit for height diff of any platform
    // used for "breakdown" platforms that can be only got to by negative jump power
    public const int breakdownPlatformHeightDiff = -4;

    // unique name
    new public string name;
    public string descriptionText; // these are actually supposed to be informative for the real game
    public string infoText; // for full info
    // TODO: animation(s)

    // changeable parameters
    public bool isBreakdown = false;
    public int heightRating = 0;
    public bool isUnlocked = false;
    public EmotionState emotionEffect = new EmotionState(0, 0, 0);
    public List<Thought> associatedThoughts = new List<Thought>();
    // specs for rhythm gameplay
    public int energyCap = 10;
    // DEFAULT - copied from "Hero" Ping Pong the animation OST
    static MeasureSpec melody = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A#_high", 0),
        new NoteSpec(3, "A#_high", 0),
        new NoteSpec(6, "D#_high", 2),
        new NoteSpec(9, "D#_high", 2),
        new NoteSpec(12, "C#_high", 4),
    });
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Closed_High_Hat", 22, EmotionType.None, "drum_kit"),
        new NoteSpec(2, "Snare_Drum_2", 20, EmotionType.None, "drum_kit"),
        new NoteSpec(4, "Closed_High_Hat", 22, EmotionType.None, "drum_kit"),
        new NoteSpec(8, "Closed_High_Hat", 22, EmotionType.None, "drum_kit"),
        new NoteSpec(10, "Snare_Drum_2", 20, EmotionType.None, "drum_kit"),
        new NoteSpec(12, "Closed_High_Hat", 22, EmotionType.None, "drum_kit"),
    });
    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "F#", 10),
        new NoteSpec(3, "F#", 11),
        new NoteSpec(6, "F#", 12),
        new NoteSpec(9, "F#", 13),
        new NoteSpec(12, "F#", 14),
    });
    static MeasureSpec base1 = base0.ReplaceAllPitches("G#");
    static MeasureSpec base2 = base0.ReplaceAllPitches("D#");
    static Song songOnce = new Song(new List<(MeasureSpec, int)> {
        (melody, 0),
        (beats, 0),
        (base0, 0),
        (melody, 1),
        (beats, 1),
        (base1, 1),
        (melody, 2),
        (beats, 2),
        (base2, 2),
        (melody, 3),
        (beats, 3),
        (base2, 3)
    });
    public Song song = songOnce.Repeated(2);

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
            return breakdownPlatformHeightDiff;
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
