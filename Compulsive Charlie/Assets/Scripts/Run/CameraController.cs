using UnityEngine;
using System.Collections;

// script for controlling camera during run
public class CameraController : MonoBehaviour
{
    private new Camera camera;

    public GameObject player;       //Public variable to store a reference to the player game object
    // different X offsets during thinking vs rhythm phases
    private const float offsetXZoomedOut = 1;
    private const float offsetXZoomedNormal = 5;
    private float offsetX;
    private const float offsetY = 1.9f;
    private bool followingY; // if in the midst of catching up on y
    private const float YThreshold = 1.5f; // threshold for adjust camera vertically
    private const float YEpsilon = .1f; // close enough to desired position

    // zooming variables
    public float zoom = 4.8f;
    float zoomedOut = 9f;
    float zoomedNormal = 5.5f; //  4.7f;
    private float smooth = 5;

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        Vector3 p = player.transform.position;
        Vector3 desiredPosition = new Vector3(p.x + offsetX, p.y + offsetY, transform.position.z);
        // Set camera to player horizontally, but offset by the calculated offset distance.
        Vector3 newPosition = new Vector3(desiredPosition.x, transform.position.y, desiredPosition.z);
        transform.position = newPosition;

        // Set camera to follow player vertically only after a significant offset
        if (Mathf.Abs(desiredPosition.y - transform.position.y) > YThreshold || followingY)
        {
            followingY = true;
            float intermediateY = Mathf.Lerp(transform.position.y, desiredPosition.y, Time.deltaTime * smooth);
            newPosition = new Vector3(transform.position.x, intermediateY, transform.position.z);
            transform.position = newPosition;
        }
        if (Mathf.Abs(desiredPosition.y - transform.position.y) < YEpsilon)
        {
            followingY = false;
        }

        // maintain specified zoom
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, zoom, Time.deltaTime * smooth);
    }

    public void ZoomOut()
    {
        zoom = zoomedOut;
        offsetX = offsetXZoomedOut;
    }

    public void ZoomNormal()
    {
        zoom = zoomedNormal;
        offsetX = offsetXZoomedNormal;
    }
}