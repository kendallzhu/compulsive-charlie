using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

// script for graphic display of active thought - right now just text but hopefully will be nicer
public class ThoughtDisplay : MonoBehaviour
{
    public GameObject bubble;
    public GameObject text;
    public RunManager runManager;
    public ThoughtMenu thoughtMenu;

    // Initialization
    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        thoughtMenu = Object.FindObjectOfType<ThoughtMenu>();
        bubble = transform.Find("Bubble").gameObject;
        text = transform.Find("Text").gameObject;
    }

    void Update()
    {
        Thought currentThought = runManager.runState.CurrentThought();
        if (currentThought)
        {
            text.GetComponent<TextMeshProUGUI>().text = currentThought.name;
        }
        // for now, only show when picking a thought
        if (thoughtMenu.currentThought)
        {
            bubble.SetActive(true);
            text.SetActive(true);
        } else
        {
            text.SetActive(false);
            bubble.SetActive(false);
        }
    }
}
