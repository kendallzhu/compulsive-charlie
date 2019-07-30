using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NoteSpec
{
    public int timing;
    public string instrument;
    public string pitch;
    public int angle;
    public EmotionType type;

    public NoteSpec(int timing, string pitch, int angle, EmotionType type = EmotionType.None, string instrument = "wood_block")
    {
        this.timing = timing;
        this.instrument = instrument;
        this.pitch = pitch;
        this.type = type;
        this.angle = angle;
    }
}

// class to help store + manipulate measures of notes
public class MeasureSpec
{
    public List<NoteSpec> notes;

    public MeasureSpec()
    {
        this.notes = new List<NoteSpec> { };
    }

    public MeasureSpec(List<NoteSpec> notes)
    {
        this.notes = notes;
    }

    // adds all notes from another measure
    public void AddMeasure(MeasureSpec measure)
    {
        this.notes.AddRange(measure.notes);
    }

    public MeasureSpec Copy()
    {
        MeasureSpec newMeasure = new MeasureSpec();
        newMeasure.AddMeasure(this);
        return newMeasure;
    }

    public MeasureSpec ReplaceAllPitches(string newPitch)
    {
        return new MeasureSpec(notes.Select(note => new NoteSpec(
            note.timing,
            newPitch,
            note.angle,
            note.type,
            note.instrument
        )).ToList());
    }
}

// class to put together a bunch of measures into a list of notes
public class Song
{
    public const int measureSize = 16;
    public List<NoteSpec> notes;

    public Song()
    {
        this.notes = new List<NoteSpec>();
    }

    public Song(List<NoteSpec> notes)
    {
        this.notes = notes;
    }

    public Song(List<(MeasureSpec, int)> measures)
    {
        this.notes = new List<NoteSpec>();
        measures.ForEach(data => this.AddMeasure(data.Item1, data.Item2));
    }

    public void AddMeasure(MeasureSpec measure, int measureNumber)
    {
        measure.notes.ForEach(note => notes.Add(new NoteSpec(
            note.timing + measureNumber * measureSize,
            note.pitch,
            note.angle,
            note.type,
            note.instrument
        )));
    }

    public int Length()
    {
        int maxTiming = notes.Max(note => note.timing);
        return maxTiming + (measureSize - maxTiming % measureSize);
    }

    public Song Repeated(int times)
    {
        MeasureSpec allNotes = new MeasureSpec(this.notes);
        Song repeatedSong = new Song();
        for (int i = 0; i < times; i++)
        {
            repeatedSong.AddMeasure(allNotes, i * this.Length() / measureSize);
        }
        return repeatedSong;
    }
}