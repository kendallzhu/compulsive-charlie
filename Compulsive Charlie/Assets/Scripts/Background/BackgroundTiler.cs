using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTiler : MonoBehaviour
{    
    private Camera mainCamera;
    // best is a multiple of the width of the screen
    private float tileSizeX;
    private float tileSizeY;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        // works smoothly with tile size as same as sprite size
        tileSizeX = 4 * 9.6f;
        tileSizeY = 4 * 5.4f;
    }

    // Update is called once per frame
    void Update()
    {
        // initialize tile components
        foreach (Transform child in transform)
        {
            // make sure the dimensions are a clean multiple of tile size
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            sr.drawMode = SpriteDrawMode.Tiled;
            sr.size = new Vector2(tileSizeX * 2, tileSizeY * 2);
        }
        // move the tile to cover the camera at all times
        float horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
        float vertExtent = Camera.main.orthographicSize;
        float x = mainCamera.transform.position.x;
        float y = mainCamera.transform.position.y;
        Vector2 pos = transform.position;
        if (x + horzExtent > pos.x + tileSizeX)
        {
            transform.position = new Vector2(pos.x + tileSizeX, pos.y);
        }
        if (y + vertExtent > pos.y + tileSizeY)
        {
            transform.position = new Vector2(pos.x, pos.y + tileSizeY);
        }
        if (y - vertExtent < pos.y - tileSizeY)
        {
            transform.position = new Vector2(pos.x, pos.y - tileSizeY);
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
