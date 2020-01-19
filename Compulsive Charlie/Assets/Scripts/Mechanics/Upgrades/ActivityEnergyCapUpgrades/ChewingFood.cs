using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChewingFood : ActivityEnergyCapUpgrade
{
    void Awake()
    {
        name = "Chewing Food";
        descriptionText = "Makes Eating More Fun";
        category = "action";
    }

    public override bool isRelevantActivity(Activity a)
    {
        Debug.Log(a.name);
        return a == Object.FindObjectOfType<BalancedMeal>() || a == Object.FindObjectOfType<Binge>();
    }
}