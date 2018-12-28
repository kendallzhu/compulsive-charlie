using UnityEngine;
using System.Collections;

// script for controlling camera during run
public class CameraController : MonoBehaviour
{
    private Camera camera;

    public GameObject player;       //Public variable to store a reference to the player game object
    private float offsetX;
    private float offsetY;

    // zooming variables
    public float zoom = 5.5f;
    float zoomedOut = 10f;
    float zoomedNormal = 5.5f;
    private float smooth = 5;

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        Vector3 offset = transform.position - player.transform.position;
        offsetX = offset.x;
        offsetY = offset.y;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 p = player.transform.position;
        transform.position = new Vector3(p.x + offsetX, p.y + offsetY, transform.position.z);
        // maintain specified zoom
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, zoom, Time.deltaTime * smooth);
    }

    public void ZoomOut()
    {
        zoom = zoomedOut;
        
    }

    public void ZoomNormal()
    {
        zoom = zoomedNormal;
    }
}