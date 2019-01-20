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
        return Math.Min(maxValue / 10, 3);
    }

    // how much energy does extreme emotion take up? (Can be negative = replenish energy)
    public int EnergyDrain()
    {
        int drain = this.Extremeness();
        if (this.Extremeness() == 0)
        {
            drain = -2;
        }
        return drain;
    }

    // shift all emotion axes toward equilibrium levels by given factor (plus one)
    public void Equilibrate(EmotionState equilibrium, float factor)
    {
        // adjust at least 1 point toward equilibrium
        int diff = equilibrium.anxiety - anxiety;
        anxiety += (int)(diff * factor) + Math.Sign(diff);

        diff = equilibrium.frustration - frustration;
        frustration += (int)(diff * factor) + Math.Sign(diff);

        diff = equilibrium.despair - despair;
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
