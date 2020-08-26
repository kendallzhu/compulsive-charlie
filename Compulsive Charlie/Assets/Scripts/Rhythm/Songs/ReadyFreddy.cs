using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class ReadyFreddy : Song
{
    public override string TitleText => "\"Ready Freddy\" (Original Song)";
    // Original Song
    static Instrument melodyInstrument = Instrument.woodBlock;
    static Instrument baseInstrument = Instrument.cello;
    static MeasureSpec melody1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Cs5", 0),
        new NoteSpec(2, "Cs5", 5),
        new NoteSpec(3, "Cs5", 10),
        new NoteSpec(4, "E5", 2),
        new NoteSpec(6, "Fs5", 2),
        new NoteSpec(9, "E5", 5),
        new NoteSpec(12, "Cs5", 2),
    }, melodyInstrument);
    static MeasureSpec melody2 = new MeasureSpec(new List<NoteSpec>
    {
        new NoteSpec(0, "E5", 5),
        new NoteSpec(6, "E5", 5),
        new NoteSpec(9, "E5", 0),
        new NoteSpec(12, "E5", 2),
    });
    static MeasureSpec melody3 = new MeasureSpec(new List<NoteSpec>
    {
        new NoteSpec(0, "B4", 5),
        new NoteSpec(6, "B4", 5),
        new NoteSpec(9, "B4", 0),
        new NoteSpec(12, "B4", 2),
    });
    static MeasureSpec melody4 = new MeasureSpec(new List<NoteSpec>
    {
        new NoteSpec(6, "B5", 5),
        new NoteSpec(8, "Gs5", 5),
        new NoteSpec(10, "Fs5", 0),
        new NoteSpec(12, "E5", 2),
        new NoteSpec(14, "E5", 2),
    });
    static MeasureSpec melody5 = new MeasureSpec(new List<NoteSpec>
    {
        new NoteSpec(0, "Cs5", 5),
        new NoteSpec(2, "Fs5", 5),
        new NoteSpec(4, "E5", 0),
    });
    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(5, "B5", 10),
    }, baseInstrument);
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(6, "Bass_Drum_1", 16),
        new NoteSpec(8, "Closed_High_Hat", 12),
        new NoteSpec(9, "Bass_Drum_1", 20),
        new NoteSpec(11, "Closed_High_Hat", 16),
        new NoteSpec(12, "Bass_Drum_1", 12),
    }, Instrument.drumkit);
    static Song songOnce = new Song(new List<(MeasureSpec, int)> {
        (melody1, 0),
        (beats, 0),
        (base0.ReplaceAllPitches("B3"), 0),
        
        (melody2, 1),
        (beats, 1),
        (base0.ReplaceAllPitches("Gs3"), 1),
        
        (melody1, 2),
        (beats, 2),
        (base0.ReplaceAllPitches("Gs3"), 2),
        
        (melody3, 3),
        (beats, 3),
        (base0.ReplaceAllPitches("B3"), 3),
        
        (melody1, 4),
        (beats, 4),
        (base0.ReplaceAllPitches("B3"), 4),
        
        (melody2, 5),
        (beats, 5),
        (base0.ReplaceAllPitches("Gs3"), 5),
        
        (melody4, 6),
        (beats, 6),
        (base0.ReplaceAllPitches("Gs3"), 6),
        
        (melody5, 7),
        (beats, 7),
        (base0.ReplaceAllPitches("E3"), 7),
    }, 20, 40, 60);
    public static Song song = songOnce.Repeated(2);
}