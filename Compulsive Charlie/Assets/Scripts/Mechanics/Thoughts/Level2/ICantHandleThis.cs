using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICantHandleThis : Thought
{
    void Awake()
    {
        name = "I Can't Handle This";
        descriptionText = "Comforting to verbalize, but careful not to lead to panic";
        isUnlocked = true;
        energyLevel = 2;
        jumpPower = 2;
        invisibleEmotions = new List<string> { "anxiety" };
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return runState.emotions.Extremeness("anxiety");
    }
}