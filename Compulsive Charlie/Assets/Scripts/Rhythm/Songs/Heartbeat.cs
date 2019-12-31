using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Heartbeat : Song
{
    MeasureSpec beat;
    public Song song;

    public Heartbeat(EmotionType emotionType)
    {
        this.beat = new MeasureSpec(new List<NoteSpec> {
            new NoteSpec(0, "Bass_Drum_1", 0, emotionType),
            new NoteSpec(0, "Bass_Drum_1", 12, EmotionType.None),
            new NoteSpec(2, "Bass_Drum_1", 0, emotionType),
            new NoteSpec(2, "Bass_Drum_1", 12, EmotionType.None),
            new NoteSpec(8, "Bass_Drum_1", 0, EmotionType.None),
            new NoteSpec(8, "Bass_Drum_1", 12, EmotionType.None),
            new NoteSpec(10, "Bass_Drum_1", 0, EmotionType.None),
            new NoteSpec(10, "Bass_Drum_1", 12, EmotionType.None),
        }, Instrument.drumkit);
        this.song = new Song(new List<(MeasureSpec, int)> {
            (beat, 0)
        }).Repeated(8);
    }
}