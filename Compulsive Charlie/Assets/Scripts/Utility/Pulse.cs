using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// put onto a text object to make the opacity pulse
public class Pulse : MonoBehaviour
{
    public float period = 3f;

    // Update is called once per frame
    void Update()
    {
        Color c = gameObject.GetComponent<TextMeshProUGUI>().color;
        float transparency = (Mathf.Sin(Time.time * 2 * Mathf.PI / period) + 1f);
        gameObject.GetComponent<TextMeshProUGUI>().color = new Color(c.r, c.g, c.b, transparency);
    }
}
