using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Esports : ActivityEnergyCapUpgrade
{
    void Awake()
    {
        name = "Esports";
        descriptionText = "Major League Gaming";
        category = "action";
    }

    public override bool isRelevantActivity(Activity a)
    {
        return a == Object.FindObjectOfType<VideoGames>();
    }
}