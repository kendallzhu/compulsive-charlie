using UnityEngine;
using System.Collections;

public class MoveFadeOut : MonoBehaviour
{
    public float fadeToAlpha = 0f;
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

    public void SetMovement(Vector2 move)
    {
        fadeDist = move.magnitude;
        direction = move;
    }

    public void SetFadeToAlpha(float alpha)
    {
        fadeToAlpha = alpha;
    }

    // Update is called once per frame
    void Update()
    {
        float step = baseSpeed / Mathf.Min(Mathf.Max(distanceTraveled, 1f), slowDownFactor);
        transform.Translate(direction.normalized * step);
        distanceTraveled += step;
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f + (fadeToAlpha - 1f) * distanceTraveled / fadeDist;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
        if (distanceTraveled > fadeDist)
        {
            Destroy(gameObject);
        }
    }
}
