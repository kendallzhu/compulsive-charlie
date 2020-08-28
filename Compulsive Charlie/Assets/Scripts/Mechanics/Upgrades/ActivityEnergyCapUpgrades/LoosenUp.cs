using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoosenUp : ActivityEnergyCapUpgrade
{
    void Awake()
    {
        name = "Loosen Up";
        descriptionText = "Makes Hanging Out and Drinking More Fun";
        category = "action";    
    }

    public override bool isRelevantActivity(Activity a)
    {
        return a == Object.FindObjectOfType<Drinking>() || a == Object.FindObjectOfType<HangOut>();
    }
}