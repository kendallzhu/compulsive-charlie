using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // expect image pos to be in center
    public GameObject image;
    public float imageWidth;
    public float imageHeight;

    public float maxX;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Instantiate(image, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        maxX = imageWidth / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Instantiate new copies of background sprite when camera view exceeds existing sprites
        float horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
        if (maxX - mainCamera.transform.position.x < horzExtent)
        {
            Instantiate(image, new Vector3(maxX + imageWidth / 2, 0, 0), Quaternion.identity);
            maxX += imageWidth;
        }
        
    }
}
