using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Luma : Song
{
    // Luma - Super Mario Galaxy: https://www.youtube.com/watch?v=c3jvWynR_Dc
    static MeasureSpec melody1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G", 6),
        new NoteSpec(4, "E_high", 8),
        new NoteSpec(8, "D_high", 10),
        new NoteSpec(12, "C_high", 12),
    });
    static MeasureSpec melody2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B", 8),
        new NoteSpec(4, "C_high", 10),
        new NoteSpec(8, "G_high", 12),
    });
    static MeasureSpec melody3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "D_high", 12),
    });
    static MeasureSpec melody5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G", 6),
        new NoteSpec(4, "E_high", 8),
        new NoteSpec(8, "D_high", 10),
        new NoteSpec(12, "C_high", 12),
    });
    static MeasureSpec melody6 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B", 8),
        new NoteSpec(4, "C_high", 10),
        new NoteSpec(8, "A_high", 12),
    });
    static MeasureSpec melody7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "G_high", 12),
    });
    static MeasureSpec melody9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C_high", 6),
        new NoteSpec(4, "A_high", 8),
        new NoteSpec(8, "G_high", 10),
        new NoteSpec(12, "F_high", 12),
    });
    static MeasureSpec melody10 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "E_high", 8),
        new NoteSpec(4, "F_high", 10),
        new NoteSpec(8, "G_high", 12),
    });
    static MeasureSpec melody11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "C_high", 12),
    });
    static MeasureSpec melody13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G", 6),
        new NoteSpec(4, "E_high", 8),
        new NoteSpec(8, "D_high", 10),
        new NoteSpec(12, "C_high", 12),
    });
    static MeasureSpec melody14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B", 8),
        new NoteSpec(4, "C_high", 10),
        new NoteSpec(8, "E_high", 12),
    });
    static MeasureSpec melody15 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "D_high", 12),
    });

    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "C_low", 0),
        new NoteSpec(12, "G_low", 0),
    });
    static MeasureSpec base1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C", 2),
    });
    static MeasureSpec base2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "B_low", 0),
        new NoteSpec(12, "G_low", 0),
    });
    static MeasureSpec base3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B_low", 2),
        new NoteSpec(4, "D", 2),
    });

    static MeasureSpec base4 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "A_low", 0),
        new NoteSpec(12, "E", 0),
    });
    static MeasureSpec base5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A", 2),
    });
    static MeasureSpec base6 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "G_low", 0),
        new NoteSpec(12, "D", 0),
    });
    static MeasureSpec base7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G", 2),
        new NoteSpec(4, "B", 2),
    });

    static MeasureSpec base8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "F_low", 0),
        new NoteSpec(12, "C", 0),
    });
    static MeasureSpec base9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "F", 2),
    });
    static MeasureSpec base10 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "E_low", 0),
        new NoteSpec(12, "C", 0),
    });
    static MeasureSpec base11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "E", 2),
        new NoteSpec(4, "G", 2),
    });

    static MeasureSpec base12 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "D_low", 0),
        new NoteSpec(12, "A_low", 0),
    });
    static MeasureSpec base13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D", 2),
    });
    static MeasureSpec base14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "G_low", 0),
        new NoteSpec(12, "D", 0),
    });
    static MeasureSpec base15 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G", 2),
        new NoteSpec(4, "B", 2),
    });

    static MeasureSpec accessory3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "B_low", 12),
    });
    static MeasureSpec accessory4 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D", 14),
        new NoteSpec(4, "B_low", 12),
    });
    static MeasureSpec accessory5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C", 16),
        new NoteSpec(4, "E", 16),
    });

    static MeasureSpec accessory7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "G_low", 12),
    });
    static MeasureSpec accessory8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B_low", 14),
        new NoteSpec(4, "G_low", 12),
    });
    static MeasureSpec accessory9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A_low", 16),
        new NoteSpec(4, "C", 16),
    });

    static MeasureSpec accessory11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "E_low", 12),
    });
    static MeasureSpec accessory12 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G_low", 14),
        new NoteSpec(4, "E_low", 12),
    });
    static MeasureSpec accessory13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G_low", 16),
        new NoteSpec(4, "D", 16),
    });

    // 8)
    static MeasureSpec beats = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(2, "Closed_High_Hat", 20, EmotionType.None, "drum_kit"),
        new NoteSpec(6, "Bass_Drum_3", 24, EmotionType.None, "drum_kit"),
        new NoteSpec(8, "Closed_High_Hat", 20, EmotionType.None, "drum_kit"),
        new NoteSpec(8, "Closed_High_Hat", 28, EmotionType.None, "drum_kit"),
        new NoteSpec(8, "Closed_High_Hat", 28, EmotionType.None, "drum_kit"),
    });

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