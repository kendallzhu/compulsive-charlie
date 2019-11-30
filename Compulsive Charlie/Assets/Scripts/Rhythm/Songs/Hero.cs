using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Hero : Song
{
    // "Hero" Ping Pong the Animation OST - https://www.youtube.com/watch?v=62qWI7CpIds
    static MeasureSpec melody = new MeasureSpec(new List<NoteSpec> {
        // new NoteSpec(0, "Piano.mf.Bb5", 0, EmotionType.None, "piano"),
        // new NoteSpec(0, "violin_As5_1_mezzo-forte_arco-normal", 0, EmotionType.None, "violin"),
        new NoteSpec(0, "As5", 0),
        new NoteSpec(3, "As5", 0),
        new NoteSpec(6, "Ds5", 2),
        new NoteSpec(9, "Ds5", 2),
        new NoteSpec(12, "Cs5", 10),
    });
    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Fs4", 10),
        new NoteSpec(3, "Fs4", 11),
        new NoteSpec(6, "Fs4", 12),
        new NoteSpec(9, "Fs4", 13),
        new NoteSpec(12, "Fs4", 14),
    });
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Closed_High_Hat", 22),
        new NoteSpec(2, "Snare_Drum_2", 20),
        new NoteSpec(4, "Closed_High_Hat", 22),
        new NoteSpec(8, "Closed_High_Hat", 22),
        new NoteSpec(10, "Snare_Drum_2", 20),
        new NoteSpec(12, "Closed_High_Hat", 22),
    }, Instrument.drumkit);
    static MeasureSpec base1 = base0.ReplaceAllPitches("Gs4");
    static MeasureSpec base2 = base0.ReplaceAllPitches("Ds4");
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