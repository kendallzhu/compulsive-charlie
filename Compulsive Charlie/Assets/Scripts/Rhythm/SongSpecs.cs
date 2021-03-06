﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// kind of djanky, but we can justa dd as we go
public enum Instrument {
    woodBlock,
    glocken,
    piano,
    piano1s,
    piano25s,
    violin, violinShort, violinVeryShort,
    cello, celloShort, celloVeryShort,
    drumkit }

public class NoteSpec
{
    public int timing;
    public string pitch;
    public int elevation;
    public EmotionType emotionType;
    public Instrument instrument;
    public string lyric;

    public NoteSpec(
        int timing, 
        string pitch, 
        int elevation, 
        EmotionType type = EmotionType.None,
        Instrument instrument = Instrument.woodBlock,
        string lyric = ""
    )
    {
        this.timing = timing;
        this.pitch = pitch;
        this.emotionType = type;
        this.elevation = elevation;
        this.instrument = instrument;
        this.lyric = lyric;
    }

    // copy constructor
    public NoteSpec(NoteSpec n)
    {
        this.timing = n.timing;
        this.pitch = n.pitch;
        this.emotionType = n.emotionType;
        this.elevation = n.elevation;
        this.instrument = n.instrument;
        this.lyric = n.lyric;
    }

    private string StringsFilePath(string instrumentString, string length)
    {
        // Helper function to fetch the format of the philharmonic orchestra files
        string prefix = instrumentString + "/" + instrumentString + "_";
        string suffix = "_arco-normal";

        List<string> volumes = new List<string> { "mezzo-forte", "forte", "fortissimo" };
        List<string> lengths = new List<string> { length, "1", "05", "025" };
        // supplement with other lengths and volumes if note is missing 8(
        foreach (string len in lengths) {
            foreach (string volume in volumes)
            {
                string path = prefix + pitch + "_" + len + "_" + volume + suffix;
                if (Resources.Load<AudioClip>(path)) return path;
            }
        }
        // use viola if we have to >8)
        foreach (string len in lengths)
        {
            foreach (string volume in volumes)
            {
                prefix = "viola/viola_";
                // supplement with other lengths and volumes if note is missing 8(
                string path = prefix + pitch + "_" + len + "_" + volume + suffix;
                if (Resources.Load<AudioClip>(path)) return path;
            }
        }
        Debug.Log("Could not find clip: " + instrumentString + ", pitch: " + pitch + "length: " + length);
        return "";
    }

    public float GetVolume()
    {
        switch (this.instrument)
        {
            // turned out this was questionable, but I'll leave the code here. vol only goes up to 1
            case Instrument.piano1s:
                return 1;
            case Instrument.piano25s:
                return 1;
            case Instrument.piano:
                return 1;
            default:
                return 1;
        }
    }

    public string GetAudioFilePath()
    {
        switch (this.instrument)
        {
            case Instrument.woodBlock:
                return "wood_block/" + pitch;
            case Instrument.glocken:
                return "glocken/" + pitch;
            case Instrument.drumkit:
                return "drum_kit/" + pitch;
            case Instrument.piano1s:
                return "piano1s/Piano.mf." + pitch;
            case Instrument.piano25s:
                return "piano.25s/Piano.mf." + pitch;
            case Instrument.piano:
                // TODO: add instruments for different volumes?
                return "piano/Piano.mf." + pitch;
            case Instrument.violin:
                return StringsFilePath("violin", "1");
            case Instrument.violinShort:
                return StringsFilePath("violin", "05");
            case Instrument.violinVeryShort:
                return StringsFilePath("violin", "025");
            case Instrument.cello:
                return StringsFilePath("cello", "1");
            case Instrument.celloShort:
                return StringsFilePath("cello", "05");
            case Instrument.celloVeryShort:
                return StringsFilePath("cello", "025");
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
    public string titleText = "";
    // combo values that are achievable, for upgrade unlocking
    public int easyCombo;
    public int mediumCombo;
    public int hardCombo; // this should be only achievable if on increased energy cap

    public const int measureSize = 16;
    public List<NoteSpec> notes;

    public Song()
    {
        this.notes = new List<NoteSpec>();
    }

    public Song(List<NoteSpec> notes, int easyCombo, int mediumCombo, int hardCombo)
    {
        this.notes = notes;
        this.easyCombo = easyCombo;
        this.mediumCombo = mediumCombo;
        this.hardCombo = hardCombo;
    }

    public Song(List<(MeasureSpec, int)> measures, int easyCombo, int mediumCombo, int hardCombo)
    {
        this.notes = new List<NoteSpec>();
        measures.ForEach(data => this.AddMeasure(data.Item1, data.Item2));
        this.easyCombo = easyCombo;
        this.mediumCombo = mediumCombo;
        this.hardCombo = hardCombo;
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

    public Song Repeated(int times, string titleText = "")
    {
        MeasureSpec allNotes = new MeasureSpec(this.notes);
        Song repeatedSong = new Song();
        repeatedSong.easyCombo = this.easyCombo;
        repeatedSong.mediumCombo = this.mediumCombo;
        repeatedSong.hardCombo = this.hardCombo;
        for (int i = 0; i < times; i++)
        {
            repeatedSong.AddMeasure(allNotes, i * this.Length() / measureSize);
        }
        repeatedSong.titleText = titleText;
        return repeatedSong;
    }
}