using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // expect image pos to be in center
    public GameObject backgroundPrefab;
    public float spriteWidth;
    public float spriteHeight;
    
    private float maxX;
    private float minX;
    private float minY;
    private float maxY;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        SpriteRenderer spriteRenderer = backgroundPrefab.GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.bounds.size.x;
        spriteHeight = spriteRenderer.bounds.size.y;
        Instantiate(backgroundPrefab, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        minX = -spriteWidth / 2;
        maxX = -spriteWidth / 2;
        minY = -spriteHeight / 2;
        maxY = spriteHeight / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Instantiate new copies of background sprite when camera view exceeds existing sprites
        float horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
        float vertExtent = Camera.main.orthographicSize;
        float x = mainCamera.transform.position.x;
        float y = mainCamera.transform.position.y;
        // deal with horizontal extensions
        float height = spriteHeight * (int)((y - spriteHeight / 2) / spriteHeight);
        if (maxX - x < horzExtent)
        {
            Instantiate(backgroundPrefab, new Vector3(maxX + spriteWidth / 2, height, 0), Quaternion.identity, this.transform);
            maxX += spriteWidth;
            minY = height - spriteHeight / 2;
            maxY = height + spriteHeight / 2;
        }
        if (x - minX < horzExtent)
        {
            Instantiate(backgroundPrefab, new Vector3(minX - spriteWidth / 2, height, 0), Quaternion.identity, this.transform);
            minX -= spriteWidth;
            minY = height - spriteHeight / 2;
            maxY = height + spriteHeight / 2;
        }
        // deal with vertical tiling
        float rightMost = maxX - spriteWidth / 2;
        float leftMost = x - (rightMost - x);
        if (maxY - y < vertExtent)
        {
            for (float lateral = rightMost; lateral >= leftMost; lateral -= spriteWidth)
            {
                Vector3 above = new Vector3(lateral, maxY + spriteHeight / 2, 0);
                Instantiate(backgroundPrefab, above, Quaternion.identity, this.transform);
            }
            maxY += spriteHeight;
        }
        if (y - minY < vertExtent)
        {
            for (float lateral = rightMost; lateral >= leftMost; lateral -= spriteWidth)
            {
                Vector3 below = new Vector3(lateral, minY - spriteHeight / 2, 0);
                Instantiate(backgroundPrefab, below, Quaternion.identity, this.transform);
            }
            minY -= spriteHeight;
        }
    }
}
