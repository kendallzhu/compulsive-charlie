using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTiler : MonoBehaviour
{
    // gameobject containing all elements that should be tiled
    // each child should have a sprite renderer
    public GameObject backgroundTile;

    private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        foreach (Transform child in backgroundTile.transform)
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            sr.drawMode = SpriteDrawMode.Tiled;
            spriteRenderers.Add(sr);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            // extend the dimensions to cover everything!
            float horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
            float vertExtent = Camera.main.orthographicSize;
            float x = mainCamera.transform.position.x;
            float y = mainCamera.transform.position.y;
            if (x + horzExtent > sr.size.x / 2)
            {
                sr.size = new Vector2(sr.size.x * 2, sr.size.y);
            }
            if (y + vertExtent > sr.size.y / 2)
            {
                sr.size = new Vector2(sr.size.x, sr.size.y * 2);
            }
        }

        /* OLD - Instantiate new copies of background sprite when camera view exceeds existing sprites
        float horzExtent = 2 * Camera.main.orthographicSize * Screen.width / Screen.height;
        float vertExtent = 2 * Camera.main.orthographicSize;
        float x = mainCamera.transform.position.x;
        float y = mainCamera.transform.position.y;
        // deal with horizontal extensions
        float height = spriteHeight * (int)((y - spriteHeight / 2) / spriteHeight);
        if (maxX - x < horzExtent)
        {
            Instantiate(backgroundTile, new Vector3(maxX + spriteWidth / 2, height, 0), Quaternion.identity, this.transform);
            maxX += spriteWidth;
            minY = height - spriteHeight / 2;
            maxY = height + spriteHeight / 2;
        }
        if (x - minX < horzExtent)
        {
            Instantiate(backgroundTile, new Vector3(minX - spriteWidth / 2, height, 0), Quaternion.identity, this.transform);
            minX -= spriteWidth;
            minY = height - spriteHeight / 2;
            maxY = height + spriteHeight / 2;
        }
        // deal with vertical tiling
        float rightMost = maxX - spriteWidth / 2;
        float leftMost = x - (rightMost - x) - 1;
        if (maxY - y < vertExtent)
        {
            for (float lateral = rightMost; lateral >= leftMost; lateral -= spriteWidth)
            {
                Vector3 above = new Vector3(lateral, maxY + spriteHeight / 2, 0);
                Instantiate(backgroundTile, above, Quaternion.identity, this.transform);
            }
            maxY += spriteHeight;
        }
        if (y - minY < vertExtent)
        {
            for (float lateral = rightMost; lateral >= leftMost; lateral -= spriteWidth)
            {
                Vector3 below = new Vector3(lateral, minY - spriteHeight / 2, 0);
                Instantiate(backgroundTile, below, Quaternion.identity, this.transform);
            }
            minY -= spriteHeight;
        } */
    }
}
