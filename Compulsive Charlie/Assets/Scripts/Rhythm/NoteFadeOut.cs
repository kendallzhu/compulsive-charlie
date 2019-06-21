using UnityEngine;
using System.Collections;

public class NoteFadeOut : MonoBehaviour
{
    private const float speed = .1f;
    // distance to move while fading
    public const float fadeDist = 3f;
    private Vector2 direction;

    private float distanceTraveled;
    // Use this for initialization
    void Awake()
    {
        distanceTraveled = 0;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed);
        distanceTraveled += speed;
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f - distanceTraveled / fadeDist;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
        if (distanceTraveled > fadeDist)
        {
            Destroy(gameObject);
        }
    }
}
