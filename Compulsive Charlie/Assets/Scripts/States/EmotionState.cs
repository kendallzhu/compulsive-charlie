using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class for storing all the emotional axes of a player
public class EmotionState
{
    public int cravingContentment;
    public int anxietyTrust;
    public int fearCuriosity;
    public int frustrationAcceptance;
    public int confusionClarity;
    public int despairJoy;
    public int shameDiginity;

    // full constructor
    public EmotionState(
        int _cravingContentment,
        int _anxietyTrust,
        int _fearCuriosity,
        int _frustrationAcceptance,
        int _confusionClarity,
        int _despairJoy,
        int _shameDiginity)
    {
        cravingContentment = _cravingContentment;
        anxietyTrust = _anxietyTrust;
        fearCuriosity = _fearCuriosity;
        frustrationAcceptance = _frustrationAcceptance;
        confusionClarity = _confusionClarity;
        despairJoy = _despairJoy;
        shameDiginity = _shameDiginity;
    }

    // uniform value constructor
    public EmotionState(int value)
    {
        cravingContentment = value;
        anxietyTrust = value;
        fearCuriosity = value;
        frustrationAcceptance = value;
        confusionClarity = value;
        despairJoy = value;
        shameDiginity = value;
    }

    // basic constructor
    public EmotionState()
    {
        cravingContentment = 0;
        anxietyTrust = 0;
        fearCuriosity = 0;
        frustrationAcceptance = 0;
        confusionClarity = 0;
        despairJoy = 0;
        shameDiginity = 0;
    }

    public int GetTotal()
    {
        // aggregate axes
        return (
            cravingContentment +
            anxietyTrust +
            fearCuriosity +
            frustrationAcceptance +
            confusionClarity +
            despairJoy +
            shameDiginity
        );
    }

    // shift all emotion axes toward equilibrium levels by given factor
    public void Equilibrate(EmotionState equilibrium, float factor)
    {
        cravingContentment += (int)((equilibrium.cravingContentment - cravingContentment) * factor);
        anxietyTrust += (int)((equilibrium.anxietyTrust - anxietyTrust) * factor);
        fearCuriosity += (int)((equilibrium.fearCuriosity - fearCuriosity) * factor);
        frustrationAcceptance += (int)((equilibrium.frustrationAcceptance - frustrationAcceptance) * factor);
        confusionClarity += (int)((equilibrium.confusionClarity - confusionClarity) * factor);
        despairJoy += (int)((equilibrium.despairJoy - despairJoy) * factor);
        shameDiginity += (int)((equilibrium.shameDiginity - shameDiginity) * factor);
    }
}
