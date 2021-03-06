﻿using UnityEngine;
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
        new NoteSpec(0, "As3", 5),
        new NoteSpec(0, "D4", 2),
        new NoteSpec(0, "F4", 0),
        new NoteSpec(3, "As3", 5),
        new NoteSpec(3, "D4", 2),
        new NoteSpec(3, "F4", 0),
        new NoteSpec(6, "C4", 5),
        new NoteSpec(6, "E4", 2),
        new NoteSpec(6, "G4", 0),
    }, melodyInstrument);
    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As1", 10),
        new NoteSpec(2, "As2", 12),
        new NoteSpec(3, "As1", 10),
        new NoteSpec(6, "C2", 10),
        new NoteSpec(6, "C3", 10),
        new NoteSpec(10, "F2", 5),
        new NoteSpec(11, "G2", 5),
    }, baseInstrument);
    static MeasureSpec melody1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(6, "G3", 5),
        new NoteSpec(6, "As3", 2),
        new NoteSpec(6, "D4", 0),
        new NoteSpec(10, "G3", 5),
        new NoteSpec(10, "As3", 2),
        new NoteSpec(10, "C4", 12),
        new NoteSpec(10, "E4", 0),
        new NoteSpec(11, "G1", 12), // (from base)
    }, melodyInstrument);
    static MeasureSpec base1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(5, "F2", 10),
        new NoteSpec(6, "G2", 10),
        new NoteSpec(14, "As1", 12),
    }, baseInstrument);
    static MeasureSpec melody2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As3", 5),
        new NoteSpec(0, "D4", 2),
        new NoteSpec(0, "F4", 0),
        new NoteSpec(3, "As3", 5),
        new NoteSpec(3, "D4", 2),
        new NoteSpec(3, "F4", 0),
        new NoteSpec(6, "C4", 5),
        new NoteSpec(6, "E4", 2),
        new NoteSpec(6, "G4", 0),
        new NoteSpec(14, "A3", 5),
        new NoteSpec(14, "As3", 2),
        new NoteSpec(14, "D4", 0),
        new NoteSpec(15, "C2", 12), // from base
    }, melodyInstrument);
    static MeasureSpec base2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As1", 12),
        new NoteSpec(2, "As2", 12),
        new NoteSpec(3, "As1", 12),
        new NoteSpec(6, "C2", 12),
        new NoteSpec(6, "C3", 12),
        new NoteSpec(10, "F3", 10),
        new NoteSpec(11, "G3", 10),
        new NoteSpec(12, "G2", 12),
        new NoteSpec(13, "C2", 10),
        new NoteSpec(14, "D2", 10),
    }, baseInstrument);
    static MeasureSpec melody3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A3", 5),
        new NoteSpec(0, "As3", 2),
        new NoteSpec(0, "D4", 0),
        new NoteSpec(8, "F4", 5),
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
        new NoteSpec(0, "A3", 5), // repeated notes? 
        new NoteSpec(0, "As3", 2),
        new NoteSpec(0, "D4", 0),
        new NoteSpec(12, "F4", 5),
    }, melodyInstrument);
    static MeasureSpec base7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C2", 12),
        new NoteSpec(12, "C2", 10),
        new NoteSpec(12, "C3", 10),
    }, baseInstrument);
    static MeasureSpec melody8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As3", 5),
        new NoteSpec(0, "D4", 2),
        new NoteSpec(0, "F4", 0),
        new NoteSpec(0, "G4", 12),
        new NoteSpec(3, "As3", 5),
        new NoteSpec(3, "D4", 2),
        new NoteSpec(3, "F4", 0),
        new NoteSpec(6, "C4", 5),
        new NoteSpec(6, "E4", 2),
        new NoteSpec(6, "G4", 0),
        new NoteSpec(10, "F5", 5),
        new NoteSpec(11, "G5", 5),
        new NoteSpec(14, "C5", 5),
        new NoteSpec(15, "D5", 5),
    }, melodyInstrument);
    static MeasureSpec base8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As1", 10),
        new NoteSpec(2, "As2", 12),
        new NoteSpec(3, "As1", 10),
        new NoteSpec(6, "C2", 10),
        new NoteSpec(6, "C3", 12),
        new NoteSpec(12, "C2", 10),
        new NoteSpec(12, "C3", 12),
    }, baseInstrument);
    static MeasureSpec melody9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(5, "F4", 5), 
        new NoteSpec(6, "G4", 5),
        new NoteSpec(7, "C4", 5),
        new NoteSpec(8, "Cs4", 5),
        new NoteSpec(9, "C4", 0),
        new NoteSpec(11, "As3", 2),
        new NoteSpec(13, "G3", 2),
    }, melodyInstrument);
    static MeasureSpec base9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Cs2", 14),
        new NoteSpec(2, "Cs3", 14),
        new NoteSpec(3, "D2", 14),
        new NoteSpec(6, "G1", 10),
        new NoteSpec(6, "G2", 12),
        new NoteSpec(10, "G1", 10),
        new NoteSpec(10, "G2", 12),
    }, baseInstrument);
    static MeasureSpec melody10 = melody6;
    static MeasureSpec base10 = base6;
    static MeasureSpec melody11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A3", 5),
        new NoteSpec(0, "As3", 2),
        new NoteSpec(0, "D4", 0),
        new NoteSpec(6, "D3", 5),
        new NoteSpec(7, "C3", 5),
        new NoteSpec(8, "D3", 5),
        new NoteSpec(9, "As3", 5),
        new NoteSpec(10, "C4", 10),
        new NoteSpec(12, "D4", 10),
        new NoteSpec(14, "F4", 10),
    }, melodyInstrument);
    static MeasureSpec base11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C2", 14),
        new NoteSpec(10, "C2", 12),
        new NoteSpec(12, "C3", 12),
        new NoteSpec(13, "C2", 12),
    }, baseInstrument);
    static MeasureSpec melody12 = melody8;
    static MeasureSpec base12 = base8;
    static MeasureSpec melody13 = melody9;
    static MeasureSpec base13 = base9;
    static MeasureSpec melody14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As3", 5),
        new NoteSpec(0, "D4", 2),
        new NoteSpec(0, "F4", 0),
        new NoteSpec(3, "As3", 5),
        new NoteSpec(3, "D4", 2),
        new NoteSpec(3, "F4", 0),
        new NoteSpec(6, "C4", 5),
        new NoteSpec(6, "E4", 2),
        new NoteSpec(6, "G4", 0),
        new NoteSpec(10, "F4", 10),
        new NoteSpec(11, "G4", 10),
        new NoteSpec(14, "A3", 5),
        new NoteSpec(14, "As3", 2),
        new NoteSpec(14, "D4", 0),
    }, melodyInstrument);
    static MeasureSpec base14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "As1", 12),
        new NoteSpec(2, "As2", 12),
        new NoteSpec(3, "As1", 12),
        new NoteSpec(6, "C2", 10),
        new NoteSpec(6, "C3", 12),
        new NoteSpec(10, "C2", 12),
        new NoteSpec(13, "C2", 12),
        new NoteSpec(14, "D2", 12),
        
    }, baseInstrument);

    static MeasureSpec melody15 = new MeasureSpec(new List<NoteSpec> {
        // new NoteSpec(0, "A3", 20),
        // new NoteSpec(0, "As3", 12),
        // new NoteSpec(0, "D4", 0),
    }, melodyInstrument);
    static MeasureSpec base15 = new MeasureSpec(new List<NoteSpec> {
        
    }, baseInstrument);
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Bass_Drum_1", 16),
        new NoteSpec(2, "Closed_High_Hat", 18),
        new NoteSpec(3, "Bass_Drum_1", 16),
        new NoteSpec(6, "Bass_Drum_1", 16),
        new NoteSpec(10, "Bass_Drum_1", 20),
        new NoteSpec(12, "Bass_Drum_1", 20),
        new NoteSpec(14, "Closed_High_Hat", 20),
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
    }, 25, 50, 75);
    public static Song song = songOnce.Repeated(1, "\"Wake Up, get up, get out there\" (Persona 5)");
}