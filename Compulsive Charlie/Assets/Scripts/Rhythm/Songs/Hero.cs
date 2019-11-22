using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Hero : Song
{
    // "Hero" Ping Pong the Animation OST - https://www.youtube.com/watch?v=62qWI7CpIds
    static MeasureSpec melody = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A#_high", 0),
        new NoteSpec(3, "A#_high", 0),
        new NoteSpec(6, "D#_high", 2),
        new NoteSpec(9, "D#_high", 2),
        new NoteSpec(12, "C#_high", 10),
    });
    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "F#", 10),
        new NoteSpec(3, "F#", 11),
        new NoteSpec(6, "F#", 12),
        new NoteSpec(9, "F#", 13),
        new NoteSpec(12, "F#", 14),
    });
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Closed_High_Hat", 22, EmotionType.None, "drum_kit"),
        new NoteSpec(2, "Snare_Drum_2", 20, EmotionType.None, "drum_kit"),
        new NoteSpec(4, "Closed_High_Hat", 22, EmotionType.None, "drum_kit"),
        new NoteSpec(8, "Closed_High_Hat", 22, EmotionType.None, "drum_kit"),
        new NoteSpec(10, "Snare_Drum_2", 20, EmotionType.None, "drum_kit"),
        new NoteSpec(12, "Closed_High_Hat", 22, EmotionType.None, "drum_kit"),
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
    public static Song song = songOnce.Repeated(3);
}