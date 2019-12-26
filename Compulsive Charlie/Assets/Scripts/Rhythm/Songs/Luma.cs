using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Luma : Song
{
    // Luma - Super Mario Galaxy: https://www.youtube.com/watch?v=c3jvWynR_Dc
    static Instrument melodyInstrument = Instrument.piano;
    static Instrument baseInstrument = Instrument.piano;
    static Instrument accessoryInstrument = Instrument.piano;
    static MeasureSpec melody1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G4", 6),
        new NoteSpec(4, "E5", 8),
        new NoteSpec(8, "D5", 10),
        new NoteSpec(12, "C5", 12),
    }, melodyInstrument);
    static MeasureSpec melody2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B4", 8),
        new NoteSpec(4, "C5", 10),
        new NoteSpec(8, "G5", 12),
    }, melodyInstrument);
    static MeasureSpec melody3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "D5", 12),
    }, melodyInstrument);
    static MeasureSpec melody5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G4", 6),
        new NoteSpec(4, "E5", 8),
        new NoteSpec(8, "D5", 10),
        new NoteSpec(12, "C5", 12),
    }, melodyInstrument);
    static MeasureSpec melody6 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B4", 8),
        new NoteSpec(4, "C5", 10),
        new NoteSpec(8, "A5", 12),
    }, melodyInstrument);
    static MeasureSpec melody7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "G5", 12),
    }, melodyInstrument);
    static MeasureSpec melody9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C5", 6),
        new NoteSpec(4, "A5", 8),
        new NoteSpec(8, "G5", 10),
        new NoteSpec(12, "F5", 12),
    }, melodyInstrument);
    static MeasureSpec melody10 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "E5", 8),
        new NoteSpec(4, "F5", 10),
        new NoteSpec(8, "G5", 12),
    }, melodyInstrument);
    static MeasureSpec melody11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "C5", 12),
    }, melodyInstrument);
    static MeasureSpec melody13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G4", 6),
        new NoteSpec(4, "E5", 8),
        new NoteSpec(8, "D5", 10),
        new NoteSpec(12, "C5", 12),
    }, melodyInstrument);
    static MeasureSpec melody14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B4", 8),
        new NoteSpec(4, "C5", 10),
        new NoteSpec(8, "E5", 12),
    }, melodyInstrument);
    static MeasureSpec melody15 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "D5", 12),
    }, melodyInstrument);

    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "C3", 0),
        new NoteSpec(12, "G3", 0),
    }, baseInstrument);
    static MeasureSpec base1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C4", 2),
    }, baseInstrument);
    static MeasureSpec base2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "B3", 0),
        new NoteSpec(12, "G3", 0),
    }, baseInstrument);
    static MeasureSpec base3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B3", 2),
        new NoteSpec(4, "D4", 2),
    }, baseInstrument);

    static MeasureSpec base4 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "A3", 0),
        new NoteSpec(12, "E4", 0),
    }, baseInstrument);
    static MeasureSpec base5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A4", 2),
    }, baseInstrument);
    static MeasureSpec base6 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "G3", 0),
        new NoteSpec(12, "D4", 0),
    }, baseInstrument);
    static MeasureSpec base7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G4", 2),
        new NoteSpec(4, "B4", 2),
    }, baseInstrument);

    static MeasureSpec base8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "F3", 0),
        new NoteSpec(12, "C4", 0),
    }, baseInstrument);
    static MeasureSpec base9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "F4", 2),
    }, baseInstrument);
    static MeasureSpec base10 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "E3", 0),
        new NoteSpec(12, "C4", 0),
    }, baseInstrument);
    static MeasureSpec base11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "E4", 2),
        new NoteSpec(4, "G4", 2),
    }, baseInstrument);

    static MeasureSpec base12 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "D3", 0),
        new NoteSpec(12, "A3", 0),
    }, baseInstrument);
    static MeasureSpec base13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D4", 2),
    }, baseInstrument);
    static MeasureSpec base14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "G3", 0),
        new NoteSpec(12, "D4", 0),
    }, baseInstrument);
    static MeasureSpec base15 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G4", 2),
        new NoteSpec(4, "B4", 2),
    }, baseInstrument);

    static MeasureSpec accessory3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "B3", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory4 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D4", 14),
        new NoteSpec(4, "B3", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C4", 16),
        new NoteSpec(4, "E4", 16),
    }, accessoryInstrument);

    static MeasureSpec accessory7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "G3", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B3", 14),
        new NoteSpec(4, "G3", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A3", 16),
        new NoteSpec(4, "C4", 16),
    }, accessoryInstrument);

    static MeasureSpec accessory11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "E3", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory12 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G3", 14),
        new NoteSpec(4, "E3", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G3", 16),
        new NoteSpec(4, "D4", 16),
    }, accessoryInstrument);

    // 8)
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(2, "Closed_High_Hat", 20),
        new NoteSpec(6, "Bass_Drum_3", 24),
        new NoteSpec(8, "Closed_High_Hat", 20),
        new NoteSpec(8, "Closed_High_Hat", 28),
        new NoteSpec(8, "Closed_High_Hat", 28),
    }, Instrument.drumkit);

    public static Song song = new Song(new List<(MeasureSpec, int)> {
        (melody1, 1),
        (melody2, 2),
        (melody3, 3),
        (base0, 0),
        (base1, 1),
        (base2, 2),
        (base3, 3),
        (accessory3, 3),
        (accessory3, 4),
        (accessory3, 5),

        (melody5, 5),
        (melody6, 6),
        (melody7, 7),
        (base4, 4),
        (base5, 5),
        (base6, 6),
        (base7, 7),
        (accessory7, 7),
        (accessory8, 8),
        (accessory9, 9),

        (melody9, 9),
        (melody10, 10),
        (melody11, 11),
        (base8, 8),
        (base9, 9),
        (base10, 10),
        (base11, 11),
        (accessory11, 11),
        (accessory12, 12),
        (accessory13, 13),

        (melody13, 13),
        (melody14, 14),
        (melody15, 15),
        (base12, 12),
        (base13, 13),
        (base14, 14),
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
}