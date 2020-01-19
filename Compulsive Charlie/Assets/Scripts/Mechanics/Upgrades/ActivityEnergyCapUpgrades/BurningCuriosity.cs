using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BurningCuriosity : ActivityEnergyCapUpgrade
{
    void Awake()
    {
        name = "Burning Curiosity";
        descriptionText = "Makes School More Fun";
        category = "action";
    }

    public override bool isRelevantActivity(Activity a)
    {
        return a == Object.FindObjectOfType<Study>() || a == Object.FindObjectOfType<Class>();
    }
}