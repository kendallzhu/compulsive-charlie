using UnityEngine;
using System.Collections;

public class MoveThenDestroy : MonoBehaviour
{
    public float slowDown = .1f;
    // movement relative to parent
    public Vector3 relativeMovement;

    // Update is called once per frame
    void Update()
    {
        Vector2 delta = relativeMovement - (transform.position - transform.parent.position);
        transform.Translate(delta * slowDown);
        if (delta.magnitude < .01f)
        {
            Destroy(gameObject);
        }
    }
}
