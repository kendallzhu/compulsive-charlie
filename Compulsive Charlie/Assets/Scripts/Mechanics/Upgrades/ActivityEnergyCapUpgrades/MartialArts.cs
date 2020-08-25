using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MartialArts : ActivityEnergyCapUpgrade
{
    void Awake()
    {
        name = "Martial Arts";
        descriptionText = "Epic new form of exercise";
        category = "action";
    }

    public override bool isRelevantActivity(Activity a)
    {
        return a == Object.FindObjectOfType<Exercise>();
    }

    public override void CustomActivate(Profile profile)
    {
        profile.exerciseMartialArts = true;
    }
}