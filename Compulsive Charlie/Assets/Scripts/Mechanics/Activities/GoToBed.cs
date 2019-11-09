using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBed : Activity
{
    // Luma - Super Mario Galaxy: https://www.youtube.com/watch?v=c3jvWynR_Dc
    static MeasureSpec melody1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G", 4),
        new NoteSpec(4, "E_high", 4),
        new NoteSpec(8, "D_high", 4),
        new NoteSpec(12, "C_high", 4),
    });
    static MeasureSpec melody2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B", 4),
        new NoteSpec(4, "C_high", 4),
        new NoteSpec(8, "G_high", 4),
    });
    static MeasureSpec melody3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "D_high", 4),
    });
    static MeasureSpec melody5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G", 4),
        new NoteSpec(4, "E_high", 4),
        new NoteSpec(8, "D_high", 4),
        new NoteSpec(12, "C_high", 4),
    });
    static MeasureSpec melody6 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B", 4),
        new NoteSpec(4, "C_high", 4),
        new NoteSpec(8, "A_high", 4),
    });
    static MeasureSpec melody7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "G_high", 4),
    });
    static MeasureSpec melody9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C_high", 4),
        new NoteSpec(4, "A_high", 4),
        new NoteSpec(8, "G_high", 4),
        new NoteSpec(12, "F_high", 4),
    });
    static MeasureSpec melody10 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "E_high", 4),
        new NoteSpec(4, "F_high", 4),
        new NoteSpec(8, "G_high", 4),
    });
    static MeasureSpec melody11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "C_high", 4),
    });
    static MeasureSpec melody13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G", 4),
        new NoteSpec(4, "E_high", 4),
        new NoteSpec(8, "D_high", 4),
        new NoteSpec(12, "C_high", 4),
    });
    static MeasureSpec melody14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B", 4),
        new NoteSpec(4, "C_high", 4),
        new NoteSpec(8, "E_high", 4),
    });
    static MeasureSpec melody15 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(4, "D_high", 4),
    });

    static MeasureSpec base0 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "C_low", 0),
        new NoteSpec(12, "G_low", 0),
    });
    static MeasureSpec base1 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C", 0),
    });
    static MeasureSpec base2 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "B_low", 0),
        new NoteSpec(12, "G_low", 0),
    });
    static MeasureSpec base3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B_low", 0),
        new NoteSpec(4, "D", 0),
    });

    static MeasureSpec base4 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "A_low", 0),
        new NoteSpec(12, "E", 0),
    });
    static MeasureSpec base5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A", 0),
    });
    static MeasureSpec base6 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "G_low", 0),
        new NoteSpec(12, "D", 0),
    });
    static MeasureSpec base7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G", 0),
        new NoteSpec(4, "B", 0),
    });

    static MeasureSpec base8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "F_low", 0),
        new NoteSpec(12, "C", 0),
    });
    static MeasureSpec base9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "F", 0),
    });
    static MeasureSpec base10 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "E_low", 0),
        new NoteSpec(12, "C", 0),
    });
    static MeasureSpec base11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "E", 0),
        new NoteSpec(4, "G", 0),
    });

    static MeasureSpec base12 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "D_low", 0),
        new NoteSpec(12, "A_low", 0),
    });
    static MeasureSpec base13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D", 0),
    });
    static MeasureSpec base14 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(8, "G_low", 0),
        new NoteSpec(12, "D", 0),
    });
    static MeasureSpec base15 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G", 0),
        new NoteSpec(4, "B", 0),
    });

    static MeasureSpec accessory3 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "B_low", 8),
    });
    static MeasureSpec accessory4 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "D", 8),
        new NoteSpec(4, "B_low", 8),
    });
    static MeasureSpec accessory5 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "C", 4),
        new NoteSpec(4, "E", 8),
    });

    static MeasureSpec accessory7 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "G_low", 8),
    });
    static MeasureSpec accessory8 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "B_low", 8),
        new NoteSpec(4, "G_low", 8),
    });
    static MeasureSpec accessory9 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "A_low", 4),
        new NoteSpec(4, "C", 8),
    });

    static MeasureSpec accessory11 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(12, "E_low", 8),
    });
    static MeasureSpec accessory12 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G_low", 8),
        new NoteSpec(4, "E_low", 8),
    });
    static MeasureSpec accessory13 = new MeasureSpec(new List<NoteSpec> {
        new NoteSpec(0, "G_low", 4),
        new NoteSpec(4, "D", 8),
    });
    static Song songOnce = new Song(new List<(MeasureSpec, int)> {
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
    });
    private Song lullaby = songOnce.Repeated(1);

    void Awake()
    {
        name = "Go To Bed";
        descriptionText = "it's all over";
        heightRating = 0;
        emotionEffect = new EmotionState(1, 0, 1);
        isUnlocked = true;
        song = lullaby;
    }

    public override void Effect(RunState runState)
    {
        runState.done = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.timeSteps > 9)
        {
            return 1;
        }
        return 0;
    }

    // make it easier to go to bed the later it is
    public override int HeightRating(RunState runState)
    {
        int lateness = System.Math.Max(0, runState.timeSteps - runState.bedTime);
        return base.HeightRating(runState) - lateness;
    }
}
