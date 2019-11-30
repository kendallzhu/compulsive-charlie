using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum Instrument { woodBlock, piano, violin, drumkit }

public class NoteSpec
{
    public int timing;
    public string pitch;
    public int angle;
    public EmotionType emotionType;
    public Instrument instrument;

    public NoteSpec(
        int timing, 
        string pitch, 
        int angle, 
        EmotionType type = EmotionType.None,
        Instrument instrument = Instrument.woodBlock
    )
    {
        this.timing = timing;
        this.pitch = pitch;
        this.emotionType = type;
        this.angle = angle;
        this.instrument = instrument;
    }

    // copy constructor
    public NoteSpec(NoteSpec n)
    {
        this.timing = n.timing;
        this.pitch = n.pitch;
        this.emotionType = n.emotionType;
        this.angle = n.angle;
        this.instrument = n.instrument;
    }

    public string GetAudioFilePath()
    {
        switch (this.instrument)
        {
            case Instrument.woodBlock:
                return "wood_block/" + pitch;
            case Instrument.drumkit:
                return "drum_kit/" + pitch;
            case Instrument.piano:
                // TODO: add instruments for different volumes?
                return "piano/Piano.mf." + pitch;
            case Instrument.violin:
                // TODO: Missing notes! Import fortissimo from philharmonic samples?
                return "violin/violin_" + pitch + "_05_mezzo-forte_arco-normal";
            default:
                Debug.Log("invalid instrument?");
                return "";
        }
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

    public MeasureSpec(List<NoteSpec> notes, Instrument instrument)
    {
        this.notes = notes;
        foreach (NoteSpec n in this.notes)
        {
            n.instrument = instrument;
        }
    }

    // adds all notes from another measure
    public void AddMeasure(MeasureSpec measure)
    {
        measure.notes.ForEach(n => this.notes.Add(new NoteSpec(n)));
    }

    public MeasureSpec Copy()
    {
        MeasureSpec newMeasure = new MeasureSpec();
        newMeasure.AddMeasure(this);
        return newMeasure;
    }

    public MeasureSpec ReplaceAllPitches(string newPitch)
    {
        MeasureSpec copy = this.Copy();
        foreach (NoteSpec n in copy.notes)
        {
            n.pitch = newPitch;
        }
        return copy;
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
        // adjust timings and compile into a list
        MeasureSpec adjustedMeasure = measure.Copy();
        adjustedMeasure.notes.ForEach(note => note.timing = note.timing + measureNumber * measureSize);
        adjustedMeasure.notes.ForEach(note => this.notes.Add(note));
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