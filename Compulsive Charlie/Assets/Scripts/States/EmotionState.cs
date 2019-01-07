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

    private float Extremeness(int value)
    {
        float shaved = Mathf.Max(Mathf.Abs(value) - 5, 0);
        return shaved / 20f;
    }

    // how much energy does extreme emotion take up? - TODO: tune
    public int EnergyDrain()
    {
        float drain = 0;
        drain += Extremeness(cravingContentment);
        drain += Extremeness(anxietyTrust);
        drain += Extremeness(fearCuriosity);
        drain += Extremeness(frustrationAcceptance);
        drain += Extremeness(confusionClarity);
        drain += Extremeness(despairJoy);
        drain += Extremeness(shameDignity);
        return (int)drain;
    }

    // checks if state is within the thresholds
    public bool Within(EmotionState minEmotions, EmotionState maxEmotions)
    {
        return (
            cravingContentment >= minEmotions.cravingContentment &&
            cravingContentment <= maxEmotions.cravingContentment &&
            anxietyTrust >= minEmotions.anxietyTrust &&
            anxietyTrust <= maxEmotions.anxietyTrust &&
            fearCuriosity >= minEmotions.fearCuriosity &&
            fearCuriosity <= maxEmotions.fearCuriosity &&
            frustrationAcceptance >= minEmotions.frustrationAcceptance &&
            frustrationAcceptance <= maxEmotions.frustrationAcceptance &&
            confusionClarity >= minEmotions.confusionClarity &&
            confusionClarity <= maxEmotions.confusionClarity &&
            despairJoy >= minEmotions.despairJoy &&
            despairJoy <= maxEmotions.despairJoy &&
            shameDignity >= minEmotions.shameDignity &&
            shameDignity <= maxEmotions.shameDignity
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
