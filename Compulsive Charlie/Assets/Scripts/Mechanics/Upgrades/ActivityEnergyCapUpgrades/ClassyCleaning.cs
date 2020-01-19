using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClassyCleaning : ActivityEnergyCapUpgrade
{
    void Awake()
    {
        name = "Classy Cleaning";
        descriptionText = "Makes Cleaning More Fun";
        category = "action";
    }

    public override bool isRelevantActivity(Activity a)
    {
        return a == Object.FindObjectOfType<Shower>() || a == Object.FindObjectOfType<Chores>();
    }
}