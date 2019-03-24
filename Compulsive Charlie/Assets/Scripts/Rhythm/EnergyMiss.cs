using UnityEngine;
using System.Collections;

public class EnergyMiss : MonoBehaviour
{
    // distance to sink
    public const float fadeDist = 1f;

    private float startY;
    // Use this for initialization
    void Awake()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -.1f, 0));
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f - Mathf.Abs(transform.position.y - startY) / fadeDist;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
        if (transform.position.y < startY - fadeDist)
        {
            Destroy(gameObject);
        }
    }
}
