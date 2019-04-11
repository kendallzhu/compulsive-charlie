using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// fade then destroy a sprite
public class FadeSprite : MonoBehaviour
{
    public float duration = 3f;
    private float startTime;

    private void Awake()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Color c = gameObject.GetComponent<SpriteRenderer>().color;
        float transparency = (duration - (Time.time - startTime)) / duration;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, transparency);
        if (transparency <= 0)
        {
            Destroy(gameObject);
        }
    }
}
