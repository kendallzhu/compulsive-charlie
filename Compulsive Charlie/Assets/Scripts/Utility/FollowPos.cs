using UnityEngine;
using System.Collections;

public class FollowPos : MonoBehaviour
{
    public GameObject follow;
    public float offsetX = 0;
    public float offsetY = 0;

    // Update is called once per frame
    void Update()
    {
        Vector2 p = follow.transform.position;
        this.transform.position = new Vector2(p.x + offsetX, p.y + offsetY);
    }
}
