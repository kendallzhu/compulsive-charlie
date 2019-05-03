using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// put onto a text object to make the opacity pulse
public class PulseText : MonoBehaviour
{
    public float period = 3f;
    private float startTime = 0;

    // reset pulse when object is enabled
    private void OnEnable()
    {
        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        Color c = gameObject.GetComponent<TextMeshProUGUI>().color;
        float timeDelta = Time.realtimeSinceStartup - startTime;
        float transparency = (Mathf.Sin(timeDelta * 2 * Mathf.PI / period) + 1f);
        gameObject.GetComponent<TextMeshProUGUI>().color = new Color(c.r, c.g, c.b, transparency);
    }
}
