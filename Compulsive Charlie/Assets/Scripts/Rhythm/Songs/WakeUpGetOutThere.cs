using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class WakeUpGetOutThere : Song
{
    // "Wake Up, get up, get out there (Persona 5)" - https://www.youtube.com/watch?v=hVDC109PCU8
    // TODO: trumpet? guitar?
    static Instrument melodyInstrument = Instrument.piano1s;
    static Instrument baseInstrument = Instrument.piano25s;

    static MeasureSpec melody0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As3", 20),
        new NoteSpec(0, "D4", 12),
        new NoteSpec(0, "F4", 0),
        new NoteSpec(3, "As3", 20),
        new NoteSpec(3, "D4", 12),
        new NoteSpec(3, "F4", 0),
        new NoteSpec(6, "C4", 20),
        new NoteSpec(6, "E4", 12),
        new NoteSpec(6, "G4", 0),
    }, melodyInstrument);
    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As1", 16),
        new NoteSpec(2, "As2", 16),
        new NoteSpec(3, "As1", 16),
        new NoteSpec(6, "C2", 6),
        new NoteSpec(6, "C3", 6),
        new NoteSpec(10, "F2", 2),
        new NoteSpec(11, "G2", 2),
    }, baseInstrument);
    static MeasureSpec melody1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(6, "G3", 20),
        new NoteSpec(6, "As3", 12),
        new NoteSpec(6, "D4", 0),
        new NoteSpec(10, "G3", 20),
        new NoteSpec(10, "As3", 20),
        new NoteSpec(10, "C4", 12),
        new NoteSpec(10, "E4", 0),
        new NoteSpec(11, "G1", 16), // (from base)
    }, melodyInstrument);
    static MeasureSpec base1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(5, "F2", 2),
        new NoteSpec(6, "G2", 6),
        new NoteSpec(14, "As1", 18),
    }, baseInstrument);
    static MeasureSpec melody2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As3", 20),
        new NoteSpec(0, "D4", 12),
        new NoteSpec(0, "F4", 0),
        new NoteSpec(3, "As3", 20),
        new NoteSpec(3, "D4", 12),
        new NoteSpec(3, "F4", 0),
        new NoteSpec(6, "C4", 20),
        new NoteSpec(6, "E4", 12),
        new NoteSpec(6, "G4", 0),
        new NoteSpec(14, "A3", 20),
        new NoteSpec(14, "As3", 12),
        new NoteSpec(14, "D4", 0),
        new NoteSpec(15, "C2", 18),
    }, melodyInstrument);
    static MeasureSpec base2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As1", 2),
        new NoteSpec(2, "As2", 2),
        new NoteSpec(3, "As1", 6),
        new NoteSpec(6, "C2", 6),
        new NoteSpec(6, "C3", 6),
        new NoteSpec(10, "F3", 14),
        new NoteSpec(11, "G3", 18),
        new NoteSpec(12, "G2", 14),
        new NoteSpec(13, "C2", 18),
        new NoteSpec(14, "D2", 14),
    }, baseInstrument);
    static MeasureSpec melody3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A3", 20),
        new NoteSpec(0, "As3", 16),
        new NoteSpec(0, "D4", 8),
        new NoteSpec(8, "F4", 16),
    }, melodyInstrument);
    static MeasureSpec base3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "G2", 14),
        new NoteSpec(14, "F2", 14),
        new NoteSpec(15, "G2", 14),
    }, baseInstrument);
    static MeasureSpec melody4 = melody0;
    static MeasureSpec base4 = base0;
    static MeasureSpec melody5 = melody1;
    static MeasureSpec base5 = base1;
    static MeasureSpec melody6 = melody2;
    static MeasureSpec base6 = base2;
    static MeasureSpec melody7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A3", 20), // repeated notes? 
        new NoteSpec(0, "As3", 16),
        new NoteSpec(0, "D4", 8),
        new NoteSpec(12, "F4", 12),
    }, melodyInstrument);
    static MeasureSpec base7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C2", 6),
        new NoteSpec(12, "C2", 8),
        new NoteSpec(12, "C3", 16),
    }, baseInstrument);
    static MeasureSpec melody8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As3", 20),
        new NoteSpec(0, "D4", 20),
        new NoteSpec(0, "F4", 12),
        new NoteSpec(0, "G4", 0),
        new NoteSpec(3, "As3", 20),
        new NoteSpec(3, "D4", 12),
        new NoteSpec(3, "F4", 0),
        new NoteSpec(6, "C4", 20),
        new NoteSpec(6, "E4", 12),
        new NoteSpec(6, "G4", 0),
        new NoteSpec(10, "F5", 0),
        new NoteSpec(11, "G5", 0),
        new NoteSpec(14, "C5", 12),
        new NoteSpec(15, "D5", 12),
    }, melodyInstrument);
    static MeasureSpec base8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As1", 2),
        new NoteSpec(2, "As2", 6),
        new NoteSpec(3, "As1", 14),
        new NoteSpec(6, "C2", 2),
        new NoteSpec(6, "C3", 14),
        new NoteSpec(12, "C2", 2),
        new NoteSpec(12, "C3", 14),
    }, baseInstrument);
    static MeasureSpec melody9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(5, "F4", 0),
        new NoteSpec(6, "G4", 12),
        new NoteSpec(7, "C4", 20),
        new NoteSpec(8, "Cs4", 0),
        new NoteSpec(9, "C4", 12),
        new NoteSpec(11, "As3", 20),
        new NoteSpec(13, "G3", 12),
    }, melodyInstrument);
    static MeasureSpec base9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Cs2", 2),
        new NoteSpec(2, "Cs3", 6),
        new NoteSpec(3, "D2", 14),
        new NoteSpec(6, "G1", 6),
        new NoteSpec(6, "G2", 2),
        new NoteSpec(10, "G1", 14),
        new NoteSpec(10, "G2", 2),
    }, baseInstrument);
    static MeasureSpec melody10 = new MeasureSpec(new List<NoteSpec> {
        // just make same as melody6?
        new NoteSpec(0, "As3", 20),
        new NoteSpec(0, "D4", 12),
        new NoteSpec(0, "F4", 0),
        new NoteSpec(3, "As3", 20),
        new NoteSpec(3, "D4", 12),
        new NoteSpec(3, "F4", 0),
        new NoteSpec(6, "C4", 20),
        new NoteSpec(6, "E4", 12),
        new NoteSpec(6, "F4", 0),
        new NoteSpec(7, "G4", 0),
        new NoteSpec(14, "A3", 20),
        new NoteSpec(14, "As3", 12),
        new NoteSpec(14, "D4", 0),
    }, melodyInstrument);
    static MeasureSpec base10 = base6;
    static MeasureSpec melody11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A3", 20),
        new NoteSpec(0, "As3", 12),
        new NoteSpec(0, "D4", 0),
        new NoteSpec(6, "D3", 0),
        new NoteSpec(7, "C3", 12),
        new NoteSpec(8, "D3", 20),
        new NoteSpec(9, "As3", 10),
        new NoteSpec(10, "C4", 12),
        new NoteSpec(12, "D4", 14),
        new NoteSpec(14, "F4", 16),
    }, melodyInstrument);
    static MeasureSpec base11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C2", 2),
        new NoteSpec(10, "C2", 2),
        new NoteSpec(12, "C3", 6),
        new NoteSpec(13, "C2", 16),
    }, baseInstrument);
    static MeasureSpec melody12 = melody8;
    static MeasureSpec base12 = base8;
    static MeasureSpec melody13 = melody9;
    static MeasureSpec base13 = base9;
    static MeasureSpec melody14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As3", 20),
        new NoteSpec(0, "D4", 12),
        new NoteSpec(0, "F4", 0),
        new NoteSpec(3, "As3", 20),
        new NoteSpec(3, "D4", 12),
        new NoteSpec(3, "F4", 0),
        new NoteSpec(6, "C4", 20),
        new NoteSpec(6, "E4", 12),
        new NoteSpec(6, "G4", 0),
        new NoteSpec(10, "F4", 0),
        new NoteSpec(11, "G4", 0),
        new NoteSpec(14, "A3", 20),
        new NoteSpec(14, "As3", 12),
        new NoteSpec(14, "D4", 0),
        new NoteSpec(15, "C2", 16),
    }, melodyInstrument);
    static MeasureSpec base14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As1", 2),
        new NoteSpec(2, "As2", 6),
        new NoteSpec(3, "As1", 16),
        new NoteSpec(6, "C2", 2),
        new NoteSpec(6, "C3", 2),
        new NoteSpec(10, "C2", 2),
        new NoteSpec(12, "G2", 6),
        new NoteSpec(13, "C2", 16),
        new NoteSpec(14, "D2", 18),
        
    }, baseInstrument);
    // delete 15?
    static MeasureSpec melody15 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A3", 20),
        new NoteSpec(0, "As3", 12),
        new NoteSpec(0, "D4", 0),
    }, melodyInstrument);
    static MeasureSpec base15 = new MeasureSpec(new List<NoteSpec> {
        
    }, baseInstrument);
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Bass_Drum_1", 22),
        new NoteSpec(2, "Closed_High_Hat", 26),
        new NoteSpec(3, "Bass_Drum_1", 22),
        new NoteSpec(6, "Bass_Drum_1", 22),
        new NoteSpec(10, "Bass_Drum_1", 24),
        new NoteSpec(12, "Bass_Drum_1", 24),
        new NoteSpec(14, "Closed_High_Hat", 22),
    }, Instrument.drumkit);
    static Song songOnce = new Song(new List<(MeasureSpec, int)> {
        (melody0, 0),
        (base0, 0),
        (melody1, 1),
        (base1, 1),
        (melody2, 2),
        (base2, 2),
        (melody3, 3),
        (base3, 3),
        (melody4, 4),
        (base4, 4),
        (melody5, 5),
        (base5, 5),
        (melody6, 6),
        (base6, 6),
        (melody7, 7),
        (base7, 7),
        (melody8, 8),
        (base8, 8),
        (melody9, 9),
        (base9, 9),
        (melody10, 10),
        (base10, 10),
        (melody11, 11),
        (base11, 11),
        (melody12, 12),
        (base12, 12),
        (melody13, 13),
        (base13, 13),
        (melody14, 14),
        (base14, 14),
        (melody15, 15),
        (base15, 15),
        (beats, 1),
        (beats, 2),
        (beats, 3),
        (beats, 4),
        (beats, 5),
        (beats, 6),
        (beats, 7),
        (beats, 8),
        (beats, 9),
        (beats, 10),
        (beats, 11),
        (beats, 12),
        (beats, 13),
        (beats, 14),
    });
    public static Song song = songOnce;
}