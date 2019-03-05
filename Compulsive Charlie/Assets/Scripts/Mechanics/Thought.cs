using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class for thought mechanic in game
public abstract class Thought : MonoBehaviour
{
    // unique name
    new public string name;
    public string descriptionText;
    public string infoText; // for full info?

    // changeable parameters
    public bool isUnlocked = false;
    public int energyCost = 0;
    public int jumpPower = 0;
    public bool rethink = false;

    // non-emotion thought-specific availability conditions 
    // (Don't use activity history - to keep modular)?
    public abstract int CustomAvailability(RunState runState);

    // whether this thought is available, given state of run
    public int Availability(RunState runState)
    {
        // check if thought is unlocked and there is enough energy to use it
        if (!isUnlocked || runState.energy < energyCost)
        {
            return 0;
        }
        return CustomAvailability(runState);
    }

    // how this thought modifies given state of run when activated
    public abstract void CustomEffect(RunState runState);

    // common effect (factored out from Effect)
    public void Effect(RunState runState)
    {
        // drain energy
        runState.IncreaseEnergy(-energyCost);
        runState.jumpPower += jumpPower;
        // make thought-specific effects
        CustomEffect(runState);
    }

    // how this thought modifies jump power when active
    // (default: no impact)
    public virtual float JumpBonus(float power)
    {
        return power;
    }

    // how this thought modifies probability of last activity being available again
    // (default: no impact)
    public virtual float Repeat(float probOffered)
    {
        return probOffered;
    }
}
