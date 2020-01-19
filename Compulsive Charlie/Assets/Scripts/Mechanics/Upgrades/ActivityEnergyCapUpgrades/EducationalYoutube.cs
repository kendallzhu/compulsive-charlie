using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EducationalYoutube : ActivityEnergyCapUpgrade
{
    void Awake()
    {
        name = "Educational YouTube";
        descriptionText = "Quality Content";
        category = "action";
    }

    public override bool isRelevantActivity(Activity a)
    {
        return a == Object.FindObjectOfType<YouTube>();
    }
}