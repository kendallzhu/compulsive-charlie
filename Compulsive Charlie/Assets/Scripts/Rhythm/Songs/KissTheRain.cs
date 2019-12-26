using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class KissTheRain : Song
{
    // "Kiss the Rain" Yiruma - https://www.youtube.com/watch?v=YtO9kCbSmx0,
    //  https://www.youtube.com/watch?v=l-Ne6HjoCqY
    static Instrument melodyInstrument = Instrument.violin;
    static Instrument baseInstrument = Instrument.cello;
    static MeasureSpec melody = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(1, "Ds4", 0),
        new NoteSpec(2, "Gs4", 0),
        new NoteSpec(3, "As4", 0),
        new NoteSpec(4, "As4", 0),
        new NoteSpec(6, "C4", 0),
        new NoteSpec(8, "C4", 0),
    }, melodyInstrument);
    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "Gs2", 0)
    }, baseInstrument);
    // TODO!
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Closed_High_Hat", 22),
        new NoteSpec(2, "Snare_Drum_2", 20),
        new NoteSpec(4, "Closed_High_Hat", 22),
        new NoteSpec(8, "Closed_High_Hat", 22),
        new NoteSpec(10, "Snare_Drum_2", 20),
        new NoteSpec(12, "Closed_High_Hat", 22),
    }, Instrument.drumkit);
    static Song songOnce = new Song(new List<(MeasureSpec, int)> {
        (melody, 0),
        (beats, 0),
        (base0, 0)
    });
    public static Song song = songOnce.Repeated(3);
}