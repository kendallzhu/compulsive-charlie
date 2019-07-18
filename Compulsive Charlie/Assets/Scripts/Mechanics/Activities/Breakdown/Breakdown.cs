using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakdown : Activity
{
    void Awake()
    {
        name = "Breakdown";
        descriptionText = "overwhelming meltdown of hopelessness";
        heightRating = 0;
        emotionEffect = new EmotionState(0, 0, 0);
        isUnlocked = true;
        isBreakdown = true;
        rhythmPattern = new List<NoteSpec> {
            new NoteSpec(0, "Bass_Drum_1", 0, EmotionType.despair, "drum_kit"),
            new NoteSpec(1, "Bass_Drum_1", 0, EmotionType.despair, "drum_kit"),
            new NoteSpec(5, "Bass_Drum_1", 0, EmotionType.despair, "drum_kit"),
            new NoteSpec(6, "Bass_Drum_1", 0, EmotionType.despair, "drum_kit"),
        };
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        EmotionState e = runState.emotions;
        if (e.GetDominantEmotion() == EmotionType.despair && e.despair >= 10)
        {
            return 1;
        }
        return 0;
    }
}
