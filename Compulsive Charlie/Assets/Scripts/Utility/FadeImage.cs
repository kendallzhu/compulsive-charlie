using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// fade image of gameobject over time, then set to inactive
public class FadeImage : MonoBehaviour
{
    public float duration = 1f;
    private float startTime;

    private void Awake()
    {
        // start out invisible
        startTime = -duration;
    }

    public void Reset()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        SetTransparency((duration - (Time.time - startTime)) / duration);
    }

    // set the image's transparency
    void SetTransparency(float t)
    {
        Color c = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Image>().color = new Color(c.r, c.g, c.b, t);
    }
}
