using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Solutions : Song
{
    public override string TitleText => "\"Solutions\" (Original Song)";
    // Original Song
    static Instrument melodyInstrument = Instrument.piano;
    static MeasureSpec melody1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(2, "F5", 0),
        new NoteSpec(6, "F5", 5),
        new NoteSpec(8, "D5", 2),
        new NoteSpec(9, "F5", 2),
        new NoteSpec(12, "D5", 5),
    }, melodyInstrument);
    static MeasureSpec melody2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(1, "C5", 10),
        new NoteSpec(2, "Gs5", 0),
        new NoteSpec(3, "G5", 5),
        new NoteSpec(5, "F5", 5),
        new NoteSpec(8, "G5", 2),
        new NoteSpec(10, "F5", 2),
    }, melodyInstrument);
    static MeasureSpec melody3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C5", 10),
        new NoteSpec(2, "Gs5", 0),
        new NoteSpec(3, "G5", 5),
        new NoteSpec(5, "F5", 5),
        new NoteSpec(7, "G5", 2),
        new NoteSpec(9, "Gs5", 2),
        new NoteSpec(11, "G5", 2),
        new NoteSpec(13, "F5", 2),
    }, melodyInstrument);
    static MeasureSpec melody4 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(2, "F5", 0),
        new NoteSpec(5, "D5", 5),
        new NoteSpec(6, "F5", 2),
        new NoteSpec(9, "D5", 5),
        new NoteSpec(10, "F5", 2),
        new NoteSpec(12, "D5", 2),
        new NoteSpec(13, "F5", 5),
        new NoteSpec(15, "D5", 2),
    }, melodyInstrument);
    static MeasureSpec melody5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A5", 0),
    }, melodyInstrument);
    static MeasureSpec melody6 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G5", 0),
        new NoteSpec(4, "G5", 5),
        new NoteSpec(6, "G5", 2),
        new NoteSpec(7, "G5", 5),
        new NoteSpec(10, "G5", 2),
        new NoteSpec(12, "G5", 5),
        new NoteSpec(13, "F5", 2),
    }, melodyInstrument);
    static MeasureSpec melody7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A5", 0),
        new NoteSpec(4, "A5", 5),
        new NoteSpec(6, "A5", 5),
        new NoteSpec(8, "A5", 2),
        new NoteSpec(9, "A5", 2),
        new NoteSpec(11, "A5", 2),
    }, melodyInstrument);
    static MeasureSpec melody8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G5", 0),
        new NoteSpec(2, "G5", 5),
        new NoteSpec(4, "G5", 2),
        new NoteSpec(6, "A5", 5),
        new NoteSpec(8, "G5", 2),
        new NoteSpec(14, "A4", 2),
        new NoteSpec(15, "A4", 2),
    }, melodyInstrument);
    static MeasureSpec melody9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A5", 0),
        new NoteSpec(6, "A5", 5),
        new NoteSpec(7, "A5", 5),
        new NoteSpec(8, "A5", 2),
        new NoteSpec(12, "A5", 2),
    }, melodyInstrument);
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(2, "Bass_Drum_1", 10),
        new NoteSpec(4, "Bass_Drum_1", 10),
        new NoteSpec(7, "Bass_Drum_1", 10),
        new NoteSpec(8, "Closed_High_Hat", 10),
        new NoteSpec(9, "Bass_Drum_1", 10),
    }, Instrument.drumkit);
    static Song songOnce = new Song(new List<(MeasureSpec, int)> {
        (melody1, 0),
        (beats, 0),
        (melody2, 1),
        (beats, 1),
        (melody1, 2),
        (beats, 2),
        (melody3, 3),
        (beats, 3),
        (melody4, 4),
        (beats, 4),
        (melody5, 5),
        (beats, 5),
        (melody6, 6),
        (beats, 6),
        (melody7, 7),
        (beats, 7),
        (melody8, 8),
        (beats, 8),
        (melody9, 9),
        (beats, 9),
        (melody1, 10),
        (beats, 10),
        (melody3, 11),
        (beats, 11),
        (melody1, 12),
        (beats, 12),
        (melody2, 13),
        (beats, 13),
    }, 20, 40, 60);
    public static Song song = songOnce.Repeated(1);
}