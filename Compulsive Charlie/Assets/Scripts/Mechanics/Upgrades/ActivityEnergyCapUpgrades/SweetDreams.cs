using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SweetDreams : ActivityEnergyCapUpgrade
{
    void Awake()
    {
        name = "Sweet Dreams";
        descriptionText = "Relaxed Sleep";
        category = "action";
    }

    public override bool isRelevantActivity(Activity a)
    {
        return a == Object.FindObjectOfType<GoToBed>() || a == Object.FindObjectOfType<SleepIn>();
    }
}