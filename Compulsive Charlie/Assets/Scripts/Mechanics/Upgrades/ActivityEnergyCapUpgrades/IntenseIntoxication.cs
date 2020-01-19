using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IntenseIntoxication : ActivityEnergyCapUpgrade
{
    void Awake()
    {
        name = "Intense Intoxication";
        descriptionText = "Makes Drinking More Fun";
        category = "action";    
    }

    public override bool isRelevantActivity(Activity a)
    {
        return a == Object.FindObjectOfType<Drinking>();
    }
}