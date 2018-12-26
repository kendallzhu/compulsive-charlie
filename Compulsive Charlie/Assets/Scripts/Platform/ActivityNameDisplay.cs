using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// script for graphic display of timesteps left - right now just text but hopefully will be nicer
public class ActivityNameDisplay : MonoBehaviour
{
    public ActivityPlatform ap;

    // Initialization
    void Start()
    {
        // set activity platform label (todo: make nicer!)
        GameObject platform = this.transform.parent.transform.parent.gameObject;
        ap = platform.GetComponent<ActivityPlatform>();
        if (ap.activity != null)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = ap.activity.name.ToString();
        }
    }
}
