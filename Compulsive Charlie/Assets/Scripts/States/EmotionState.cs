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
    public int shameDignity;

    // full constructor
    public EmotionState(
        int _cravingContentment,
        int _anxietyTrust,
        int _fearCuriosity,
        int _frustrationAcceptance,
        int _confusionClarity,
        int _despairJoy,
        int _shameDignity)
    {
        cravingContentment = _cravingContentment;
        anxietyTrust = _anxietyTrust;
        fearCuriosity = _fearCuriosity;
        frustrationAcceptance = _frustrationAcceptance;
        confusionClarity = _confusionClarity;
        despairJoy = _despairJoy;
        shameDignity = _shameDignity;
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
        shameDignity = value;
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
        shameDignity = 0;
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
            shameDignity
        );
    }

    // shift all emotion axes toward equilibrium levels by given factor (plus one)
    public void Equilibrate(EmotionState equilibrium, float factor)
    {
        // kinda cumbersome, but I think it's better like this so they actually reach equilibrium
        int diff = equilibrium.cravingContentment - cravingContentment;
        cravingContentment += (int)(diff * factor) + System.Math.Sign(diff);

        diff = equilibrium.anxietyTrust - anxietyTrust;
        anxietyTrust += (int)(diff * factor) + System.Math.Sign(diff);

        diff = equilibrium.fearCuriosity - fearCuriosity;
        fearCuriosity += (int)(diff * factor) + System.Math.Sign(diff);

        diff = equilibrium.frustrationAcceptance - frustrationAcceptance;
        frustrationAcceptance += (int)(diff * factor) + System.Math.Sign(diff);

        diff = equilibrium.confusionClarity - confusionClarity;
        confusionClarity += (int)(diff * factor) + System.Math.Sign(diff);

        diff = equilibrium.despairJoy - despairJoy;
        despairJoy += (int)(diff * factor) + System.Math.Sign(diff);

        diff = equilibrium.shameDignity - shameDignity;
        shameDignity += (int)(diff * factor) + System.Math.Sign(diff);
    }
}
