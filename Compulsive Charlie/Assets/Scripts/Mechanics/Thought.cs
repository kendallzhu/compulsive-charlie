using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class for thought mechanic in game
public abstract class Thought : MonoBehaviour
{
    // consts
    private const float colorBase = 0f;

    // unique name
    new public string name;
    public string descriptionText;
    public string infoText; // for full info?

    // changeable parameters
    public bool isUnlocked = false;
    public int energyCost = 0;
    public int jumpPower = 0;
    public bool rethink = false;
    public List<string> invisibleEmotions = new List<string>();

    // derives color from the invisible emotions list
    public Color GetColor()
    {
        float r = colorBase, g = colorBase, b = colorBase;
        if (invisibleEmotions.Contains("anxiety"))
        {
            g = 1;
        }
        if (invisibleEmotions.Contains("frustration"))
        {
            r = 1;
        }
        if (invisibleEmotions.Contains("despair"))
        {
            b = 1;
        }
        return new Color(r, g, b, .4f);
    }
    // version of color to tint background after selecting this thought
    public Color BackgroundColor()
    {
        Color c = GetColor();
        // for sprite, subtract colors to get desired tint
        return new Color(
            1 - (c.g + c.b) / 5,
            1 - (c.r + c.b) / 5, 
            1 - (c.r + c.g) / 5, 
            1
        );
    }

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
        // set background tint
        GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("Background");
        foreach (GameObject bg in backgrounds)
        {
            bg.GetComponent<SpriteRenderer>().color = BackgroundColor();
        }
        // drain energy - (SYNCHRONIZING ENERGY WITH COMBO)
        // runState.IncreaseEnergy(-energyCost);
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
