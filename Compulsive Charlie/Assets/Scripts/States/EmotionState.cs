﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public void AddAnxiety(int val)
    {
        anxiety = Math.Max(0, anxiety + val);
    }

    public void AddFrustration(int val)
    {
        frustration = Math.Max(0, frustration + val);
    }

    public void AddDespair(int val)
    {
        despair = Math.Max(0, despair + val);
    }

    // return name of emotion with highest magnitude
    public string GetDominantEmotion()
    {
        int maxValue = Math.Max(anxiety, Math.Max(frustration, despair));
        if (maxValue == 0)
        {
            return "None";
        }
        if (frustration == maxValue)
        {
            return "frustration";
        }
        else if (anxiety == maxValue)
        {
            return "anxiety";
        }
        else
        {
            return "despair";
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

    public int Extremeness(string e)
    {
        if (e == "anxiety")
        {
            return Level(anxiety);
        }
        else if (e == "frustration")
        {
            return Level(frustration);
        }
        else if (e == "despair")
        {
            return Level(despair);
        }
        Debug.Log("Extremeness called with wrong args");
        return 0;
    }

    // how much craving does extreme emotion generate?
    public int CravingIncrease()
    {
        return 0; // this.Extremeness() - 1;
    }

    // shift all emotion axes towards 0 by given factor (plus one)
    public void Equilibrate(float factor)
    {
        // adjust at least 1 point toward equilibrium
        int diff = 0 - anxiety;
        anxiety += (int)(diff * factor) + Math.Sign(diff);

        diff = 0 - frustration;
        frustration += (int)(diff * factor) + Math.Sign(diff);

        diff = 0 - despair;
        despair += (int)(diff * factor) + Math.Sign(diff);

        // floor emotions at 0
        anxiety = Math.Max(anxiety, 0);
        frustration = Math.Max(frustration, 0);
        despair = Math.Max(despair, 0);
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
