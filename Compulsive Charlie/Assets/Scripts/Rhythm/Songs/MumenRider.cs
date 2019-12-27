using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class MumenRider: Song
{
    // "One Punch Man Sad Theme" - https://www.youtube.com/watch?v=3yDvBmM0tps
    // alternative : https://www.youtube.com/watch?v=3yDvBmM0tps
    static Instrument melodyInstrument = Instrument.violin;
    static Instrument baseInstrument = Instrument.cello;
    static MeasureSpec melody0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(6, "A4", 0),
        new NoteSpec(8, "B4", 0),
        new NoteSpec(11, "Cs4", 0),
        new NoteSpec(14, "D4", 0),
    }, melodyInstrument);
    static MeasureSpec melody1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D4", 0),
        new NoteSpec(12, "Cs4", 0),
        new NoteSpec(14, "D4", 0),
    }, melodyInstrument);
    static MeasureSpec base1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B2", 0),
        new NoteSpec(8, "Fs3", 0),
        new NoteSpec(10, "B3", 0),
        new NoteSpec(12, "D4", 0),
    }, baseInstrument);
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Closed_High_Hat", 22),
        new NoteSpec(2, "Snare_Drum_2", 20),
        new NoteSpec(4, "Closed_High_Hat", 22),
        new NoteSpec(8, "Closed_High_Hat", 22),
        new NoteSpec(10, "Snare_Drum_2", 20),
        new NoteSpec(12, "Closed_High_Hat", 22),
    }, Instrument.drumkit);
    static Song songOnce = new Song(new List<(MeasureSpec, int)> {
        (melody0, 0),
        (melody1, 1),
        (base1, 1)
    });
    public static Song song = songOnce;
}