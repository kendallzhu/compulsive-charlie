using UnityEngine;
using System.Collections;

public class NoteFadeOut : MonoBehaviour
{
    public float fadeDist = 2.4f;
    public float baseSpeed = .1f;
    public float slowDownFactor = 2f;
    // distance to move while fading
    public Vector2 direction;

    private float distanceTraveled;
    // Use this for initialization
    void Awake()
    {
        distanceTraveled = 0;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    // Update is called once per frame
    void Update()
    {
        float step = baseSpeed / Mathf.Min(Mathf.Max(distanceTraveled, 1f), slowDownFactor);
        transform.Translate(direction.normalized * step);
        distanceTraveled += step;
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f - distanceTraveled / fadeDist;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
        if (distanceTraveled > fadeDist)
        {
            Destroy(gameObject);
        }
    }
}
