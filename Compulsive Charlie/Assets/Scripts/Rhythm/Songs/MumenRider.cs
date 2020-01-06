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
        new NoteSpec(12, "Cs4", 2),
        new NoteSpec(14, "D4", 0),
    }, melodyInstrument);
    static MeasureSpec base1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B2", 6),
        new NoteSpec(8, "Fs3", 8),
        new NoteSpec(10, "B3", 10),
        new NoteSpec(12, "D4", 12),
    }, baseInstrument);
    static MeasureSpec melody2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(6, "A4", 4),
        new NoteSpec(8, "D5", 2),
        new NoteSpec(10, "E5", 0),
        new NoteSpec(12, "Fs5", 2),
        new NoteSpec(13, "G5", 4),
    }, melodyInstrument);
    static MeasureSpec base2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G2", 6),
        new NoteSpec(2, "D3", 8),
        new NoteSpec(4, "G3", 10),
        new NoteSpec(8, "B3", 12),
    }, baseInstrument);
    static MeasureSpec melody3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Fs4", 16),
        new NoteSpec(0, "D5", 0),
        new NoteSpec(8, "A5", 2),
    }, melodyInstrument);
    static MeasureSpec base3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D3", 6),
        new NoteSpec(2, "A3", 8),
        new NoteSpec(4, "D4", 10),
        new NoteSpec(8, "A3", 12),
    }, baseInstrument);
    static MeasureSpec melody4 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "E4", 14),
        new NoteSpec(0, "A5", 16),
        new NoteSpec(0, "E5", 0),
        new NoteSpec(6, "A4", 14),
        new NoteSpec(8, "Fs5", 2),
        new NoteSpec(10, "G5", 4),
        new NoteSpec(12, "E5", 6),
        new NoteSpec(14, "Fs5", 2),
    }, melodyInstrument);
    static MeasureSpec base4 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A2", 6),
        new NoteSpec(2, "E3", 8),
        new NoteSpec(4, "Cs4", 10),
    }, baseInstrument);
    static MeasureSpec melody5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B4", 0),
        new NoteSpec(0, "D5", 17),
        new NoteSpec(8, "D5", 12),
        new NoteSpec(11, "E5", 14),
        new NoteSpec(14, "Fs5", 17),
    }, melodyInstrument);
    static MeasureSpec base5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B2", 6),
        new NoteSpec(2, "Fs3", 8),
        new NoteSpec(4, "Cs4", 10),
        new NoteSpec(8, "D4", 12),
    }, baseInstrument);
    static MeasureSpec melody6 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D5", 12),
        new NoteSpec(0, "Fs5", 0),
        new NoteSpec(4, "D6", 0),
        new NoteSpec(8, "Cs6", 2),
        new NoteSpec(12, "D6", 6),
        new NoteSpec(12, "G5", 14),
    }, melodyInstrument);
    static MeasureSpec base6 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G2", 6),
        new NoteSpec(2, "D3", 8),
        new NoteSpec(4, "G4", 10),
        new NoteSpec(8, "B4", 12),
        new NoteSpec(12, "G4", 10),
    }, baseInstrument);
    static MeasureSpec melody7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D5", 14),
        new NoteSpec(0, "Fs5", 0),
        new NoteSpec(0, "A5", 20),
    }, melodyInstrument);
    static MeasureSpec base7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D3", 6),
        new NoteSpec(2, "A3", 8),
        new NoteSpec(4, "D4", 10),
        new NoteSpec(6, "A3", 12),
        new NoteSpec(10, "A3", 10),
        new NoteSpec(12, "D4", 8),
    }, baseInstrument);
    static MeasureSpec melody8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Cs5", 0),
        new NoteSpec(0, "Fs5", 14),
        new NoteSpec(4, "As5", 2),
        new NoteSpec(6, "Fs5", 4),
        new NoteSpec(8, "B5", 6),
        new NoteSpec(10, "Fs5", 4),
        new NoteSpec(12, "Fs5", 14),
        new NoteSpec(12, "As5", 20),
        new NoteSpec(12, "Cs6", 2),
    }, melodyInstrument);
    static MeasureSpec base8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Fs2", 6),
    }, baseInstrument);
    static MeasureSpec melody9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "Fs4", 0),
        new NoteSpec(8, "A4", 0),
        new NoteSpec(12, "E5", 0),
    }, melodyInstrument);
    static MeasureSpec melody10 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B5", 0),
        new NoteSpec(0, "D5", 14),
        new NoteSpec(12, "Cs5", 2),
        new NoteSpec(14, "D5", 17),
    }, melodyInstrument);
    static MeasureSpec base10 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B2", 6),
        new NoteSpec(2, "Fs3", 8),
        new NoteSpec(4, "B3", 10),
        new NoteSpec(6, "D4", 12),
        new NoteSpec(10, "A3", 10),
        new NoteSpec(12, "Fs3", 8),
    }, baseInstrument);
    static MeasureSpec melody11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "E5", 2),
    }, melodyInstrument);
    static MeasureSpec base11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G2", 6),
        new NoteSpec(2, "D3", 8),
        new NoteSpec(4, "G3", 10),
        new NoteSpec(6, "B3", 12),
        new NoteSpec(10, "G3", 10),
        new NoteSpec(14, "D3", 8),
    }, baseInstrument);
    static MeasureSpec melody12 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Fs5", 0),
        new NoteSpec(6, "D5", 2),
        new NoteSpec(12, "G5", 4),
    }, melodyInstrument);
    static MeasureSpec base12 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D3", 6),
        new NoteSpec(2, "A3", 8),
        new NoteSpec(4, "D4", 10),
        new NoteSpec(6, "Fs4", 12),
    }, baseInstrument);
    static MeasureSpec melody13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A4", 14),
        new NoteSpec(0, "Fs5", 0),
        new NoteSpec(3, "E5", 17),
        new NoteSpec(6, "D5", 2),
        new NoteSpec(10, "Cs5", 20),
        new NoteSpec(12, "E5", 4),
    }, melodyInstrument);
    static MeasureSpec base13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A2", 6),
        new NoteSpec(2, "E3", 8),
        new NoteSpec(4, "Cs3", 10),
        new NoteSpec(6, "E4", 12),
        new NoteSpec(10, "A3", 10),
        new NoteSpec(12, "E3", 8),
    }, baseInstrument);
    static MeasureSpec melody14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B4", 14),
        new NoteSpec(0, "D5", 0),
        new NoteSpec(10, "A4", 2),
        new NoteSpec(12, "E5", 4),
    }, melodyInstrument);
    static MeasureSpec base14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B2", 6),
        new NoteSpec(2, "Fs3", 8),
        new NoteSpec(4, "Cs4", 10),
        new NoteSpec(6, "D4", 12),
        new NoteSpec(10, "Fs3", 10),
        new NoteSpec(12, "B3", 8),
        new NoteSpec(12, "D4", 6),
    }, baseInstrument); 
    static MeasureSpec melody15 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G4", 4),
        new NoteSpec(0, "D5", 0),
        new NoteSpec(12, "E5", 14),
    }, melodyInstrument);
    static MeasureSpec base15 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G2", 6),
        new NoteSpec(2, "D3", 8),
        new NoteSpec(4, "G3", 10),
        new NoteSpec(6, "B3", 12),
        new NoteSpec(10, "G3", 10),
        new NoteSpec(12, "D3", 8),
    }, baseInstrument);
    static MeasureSpec melody16 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A4", 6),
        new NoteSpec(0, "Fs5", 0),
        new NoteSpec(6, "D5", 2),
        new NoteSpec(12, "G5", 4),
    }, melodyInstrument);
    static MeasureSpec base16 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D3", 6),
        new NoteSpec(2, "A3", 8),
        new NoteSpec(4, "D4", 10),
        new NoteSpec(6, "A3", 12),
        new NoteSpec(8, "Cs4", 10),
        new NoteSpec(10, "A3", 8),
        new NoteSpec(12, "D4", 6),
        new NoteSpec(14, "A3", 10),
    }, baseInstrument);
    static MeasureSpec melody17 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A4", 0),
        new NoteSpec(0, "Fs5", 14),
        new NoteSpec(0, "E5", 20),
    }, melodyInstrument);
    static MeasureSpec base17 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A2", 6),
        new NoteSpec(2, "E3", 8),
        new NoteSpec(4, "A3", 10),
        new NoteSpec(6, "Cs4", 12),
    }, baseInstrument);
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "Bass_Drum_1", 22),
        new NoteSpec(2, "Bass_Drum_1", 24),
        new NoteSpec(3, "Closed_High_Hat", 22),
        new NoteSpec(6, "Bass_Drum_1", 24),
        new NoteSpec(10, "Bass_Drum_1", 22),
        new NoteSpec(12, "Closed_High_Hat", 24),
    }, Instrument.drumkit);
    static Song songOnce = new Song(new List<(MeasureSpec, int)> {
        (melody0, 0),
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
        (melody16, 16),
        (base16, 16),
        (melody17, 17),
        (base17, 17),
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
        (beats, 15),
        (beats, 16),
        (beats, 17),
    });
    public static Song song = songOnce;
}