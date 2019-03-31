﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EmotionType { None, anxiety, frustration, despair }

// class for storing the core emotional axes of a player
public class EmotionState
{
    public int anxiety;
    public int frustration;
    public int despair;

    // constructor
    public EmotionState(
        int _anxiety,
        int _frustration,
        int _despair)
    {
        anxiety = _anxiety;
        frustration = _frustration;
        despair = _despair;
    }
    
    // copy constructor
    public EmotionState(EmotionState e)
    {
        anxiety = e.anxiety;
        frustration = e.frustration;
        despair = e.despair;
    }

    public int GetSum()
    {
        return anxiety + frustration + despair;
    }

    public int DotProduct(EmotionState other)
    {
        return anxiety * other.anxiety + frustration * other.frustration + despair * other.despair;
    }

    // methods for modifying and flooring values
    public void Add(EmotionType type, int val)
    {
        if (type == EmotionType.anxiety)
        {
            anxiety = Math.Max(0, anxiety + val);
        }
        else if (type == EmotionType.frustration)
        {
            frustration = Math.Max(0, frustration + val);
        }
        else if (type == EmotionType.despair)
        {
            despair = Math.Max(0, despair + val);
        }
    }
    public void Add(EmotionState other)
    {
        Add(EmotionType.anxiety, other.anxiety);
        Add(EmotionType.frustration, other.frustration);
        Add(EmotionType.despair, other.despair);
    }

    // return name of emotion with highest magnitude
    public EmotionType GetDominantEmotion()
    {
        int maxValue = Math.Max(anxiety, Math.Max(frustration, despair));
        if (maxValue == 0)
        {
            return EmotionType.None;
        }
        if (frustration == maxValue)
        {
            return EmotionType.frustration;
        }
        else if (anxiety == maxValue)
        {
            return EmotionType.anxiety;
        }
        else
        {
            return EmotionType.despair;
        }
    }

    // return discretized "level" (0-3) of emotion value
    public int Level(int value)
    {
        if (value == 0)
        {
            return 0;
        }
        return Math.Min(value / 10 + 1, 3);
    }

    // return discretized "level" of emotion with highest magnitude
    public int Extremeness()
    {
        int maxValue = Math.Max(anxiety, Math.Max(frustration, despair));
        return Level(maxValue);
    }

    public int Extremeness(EmotionType e)
    {
        if (e == EmotionType.anxiety)
        {
            return Level(anxiety);
        }
        else if (e == EmotionType.frustration)
        {
            return Level(frustration);
        }
        else if (e == EmotionType.despair)
        {
            return Level(despair);
        }
        Debug.Log("Extremeness called with invalid emotion name");
        return 0;
    }

    // shift all emotion axes towards 0 by given factor (plus one)
    public void Equilibrate(float factor)
    {
        Equilibrate(EmotionType.anxiety, factor);
        Equilibrate(EmotionType.frustration, factor);
        Equilibrate(EmotionType.despair, factor);
    }

    public void Equilibrate(EmotionType e, float factor = .2f)
    {
        if (e == EmotionType.anxiety)
        {
            int diff = 0 - anxiety;
            anxiety += (int)(diff * factor) + Math.Sign(diff);
        }
        else if (e == EmotionType.frustration)
        {
            int diff = 0 - frustration;
            frustration += (int)(diff * factor) + Math.Sign(diff);
        }
        else if (e == EmotionType.despair)
        {
            int diff = 0 - despair;
            despair += (int)(diff * factor) + Math.Sign(diff);
        } else
        {
            Debug.Log("Extremeness called with invalid emotion Name");
        }
    }

    // checks if state is within the thresholds
    public bool Within(EmotionState minEmotions, EmotionState maxEmotions)
    {
        return (
            anxiety >= minEmotions.anxiety &&
            anxiety <= maxEmotions.anxiety &&
            frustration >= minEmotions.frustration &&
            frustration <= maxEmotions.frustration &&
            despair >= minEmotions.despair &&
            despair <= maxEmotions.despair
        );
    }
}
