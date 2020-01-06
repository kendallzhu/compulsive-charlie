using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Luma : Song
{
    // Luma - Super Mario Galaxy: https://www.youtube.com/watch?v=c3jvWynR_Dc
    static Instrument melodyInstrument = Instrument.glocken;
    static Instrument baseInstrument = Instrument.glocken;
    static Instrument accessoryInstrument = Instrument.glocken;
    static MeasureSpec melody1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G6", 5),
        new NoteSpec(4, "E7", 5),
        new NoteSpec(8, "D7", 5),
        new NoteSpec(12, "C7", 5),
    }, melodyInstrument);
    static MeasureSpec melody2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B6", 5),
        new NoteSpec(4, "C7", 5),
        new NoteSpec(8, "G7", 10),
    }, melodyInstrument);
    static MeasureSpec melody3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "D7", 10),
    }, melodyInstrument);
    static MeasureSpec melody5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G6", 5),
        new NoteSpec(4, "E7", 5),
        new NoteSpec(8, "D7", 5),
        new NoteSpec(12, "C7", 5),
    }, melodyInstrument);
    static MeasureSpec melody6 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B6", 5),
        new NoteSpec(4, "C7", 10),
        new NoteSpec(8, "A7", 10),
    }, melodyInstrument);
    static MeasureSpec melody7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "G7", 10),
    }, melodyInstrument);
    static MeasureSpec melody9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C7", 5),
        new NoteSpec(4, "A7", 5),
        new NoteSpec(8, "G7", 5),
        new NoteSpec(12, "F7", 5),
    }, melodyInstrument);
    static MeasureSpec melody10 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "E7", 5),
        new NoteSpec(4, "F7", 10),
        new NoteSpec(8, "G7", 10),
    }, melodyInstrument);
    static MeasureSpec melody11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "C7", 10),
    }, melodyInstrument);
    static MeasureSpec melody13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G6", 5),
        new NoteSpec(4, "E7", 5),
        new NoteSpec(8, "D7", 5),
        new NoteSpec(12, "C7", 5),
    }, melodyInstrument);
    static MeasureSpec melody14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B6", 5),
        new NoteSpec(4, "C7", 10),
        new NoteSpec(8, "E7", 10),
    }, melodyInstrument);
    static MeasureSpec melody15 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "D7", 10),
    }, melodyInstrument);

    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "C5", 0),
        new NoteSpec(12, "G5", 0),
    }, baseInstrument);
    static MeasureSpec base1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C6", 2),
    }, baseInstrument);
    static MeasureSpec base2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "B5", 0),
        new NoteSpec(12, "G5", 0),
    }, baseInstrument);
    static MeasureSpec base3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B5", 2),
        new NoteSpec(4, "D6", 2),
    }, baseInstrument);

    static MeasureSpec base4 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "A5", 0),
        new NoteSpec(12, "E6", 0),
    }, baseInstrument);
    static MeasureSpec base5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A6", 2),
    }, baseInstrument);
    static MeasureSpec base6 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "G5", 0),
        new NoteSpec(12, "D6", 0),
    }, baseInstrument);
    static MeasureSpec base7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G6", 2),
        new NoteSpec(4, "B6", 2),
    }, baseInstrument);

    static MeasureSpec base8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "F5", 0),
        new NoteSpec(12, "C6", 0),
    }, baseInstrument);
    static MeasureSpec base9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "F6", 2),
    }, baseInstrument);
    static MeasureSpec base10 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "E5", 0),
        new NoteSpec(12, "C6", 0),
    }, baseInstrument);
    static MeasureSpec base11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "E6", 2),
        new NoteSpec(4, "G6", 2),
    }, baseInstrument);

    static MeasureSpec base12 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "D5", 0),
        new NoteSpec(12, "A5", 0),
    }, baseInstrument);
    static MeasureSpec base13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D6", 2),
    }, baseInstrument);
    static MeasureSpec base14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "G5", 0),
        new NoteSpec(12, "D6", 0),
    }, baseInstrument);
    static MeasureSpec base15 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G6", 2),
        new NoteSpec(4, "B6", 2),
    }, baseInstrument);

    static MeasureSpec accessory3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "B5", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory4 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D6", 14),
        new NoteSpec(4, "B5", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C6", 16),
        new NoteSpec(4, "E6", 16),
    }, accessoryInstrument);

    static MeasureSpec accessory7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "G5", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B5", 14),
        new NoteSpec(4, "G5", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A5", 16),
        new NoteSpec(4, "C6", 16),
    }, accessoryInstrument);

    static MeasureSpec accessory11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "E5", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory12 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G5", 14),
        new NoteSpec(4, "E5", 12),
    }, accessoryInstrument);
    static MeasureSpec accessory13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G5", 16),
        new NoteSpec(4, "D6", 16),
    }, accessoryInstrument);

    // 8)
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(2, "Closed_High_Hat", 18),
        new NoteSpec(6, "Bass_Drum_3", 20),
        new NoteSpec(8, "Closed_High_Hat", 18),
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