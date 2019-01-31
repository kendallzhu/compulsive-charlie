using System.Collections;
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

    // return discretized "level" (0-3) of emotion with highest magnitude
    public int Extremeness()
    {
        int maxValue = Math.Max(anxiety, Math.Max(frustration, despair));
        if (maxValue == 0)
        {
            return 0;
        }
        return Math.Min(maxValue / 10 + 1, 3);
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
