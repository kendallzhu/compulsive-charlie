using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Hero : Song
{
    // "Hero" Ping Pong the Animation OST - https://www.youtube.com/watch?v=62qWI7CpIds
    static Instrument melodyInstrument = Instrument.woodBlock;
    static Instrument baseInstrument = Instrument.woodBlock;
    static MeasureSpec melody = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As5", 0),
        new NoteSpec(3, "As5", 0),
        new NoteSpec(6, "Ds5", 2),
        new NoteSpec(9, "Ds5", 2),
        new NoteSpec(12, "Cs5", 5),
    }, melodyInstrument);
    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Fs4", 5),
        new NoteSpec(3, "Fs4", 5),
        new NoteSpec(6, "Fs4", 5),
        new NoteSpec(9, "Fs4", 10),
        new NoteSpec(12, "Fs4", 10),
    }, baseInstrument);
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(2, "Bass_Drum_3", 16),
        new NoteSpec(4, "Closed_High_Hat", 12),
        new NoteSpec(6, "Bass_Drum_3", 20),
        new NoteSpec(10, "Bass_Drum_3", 16),
        new NoteSpec(12, "Closed_High_Hat", 12),
        new NoteSpec(14, "Bass_Drum_3", 20),
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
    }, 20, 40, 60);
    public static Song song = songOnce.Repeated(3, "\"Hero\" (Ping Pong the Animation)");
}