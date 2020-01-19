using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnergeticExercise : ActivityEnergyCapUpgrade
{
    void Awake()
    {
        name = "Energetic Exercise";
        descriptionText = "Makes Physical Activity More Fun";
        category = "action";
    }

    public override bool isRelevantActivity(Activity a)
    {
        return a == Object.FindObjectOfType<Walk>();
    }
}