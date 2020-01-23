using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

// script for graphic display of active thought - right now just text but hopefully will be nicer
public class ThoughtDisplay : MonoBehaviour
{
    public RunManager runManager;
    public ThoughtMenu thoughtMenu;
    private float x;
    private float y;

    // Initialization
    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        thoughtMenu = Object.FindObjectOfType<ThoughtMenu>();
        x = transform.localPosition.x;
        y = transform.localPosition.y;
    }

    void Update()
    {
        Thought currentThought = runManager.runState.CurrentThought();
        if (currentThought)
        {
            string quote = "\"" + currentThought.name + "\"";
            gameObject.GetComponent<TextMeshProUGUI>().text = " " + quote;
        }
        if (thoughtMenu.currentThought == null)
        {
            transform.localPosition = new Vector2(x + 3.5f, y);
        }else
        {
            transform.localPosition = new Vector2(x, y);
        }
    }
}
