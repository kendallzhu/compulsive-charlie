using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    // static backgrounds
    public GameObject bgStatic;
    public GameObject staticBase;
    public GameObject staticOverlay;

    public Sprite cloudy;
    public Sprite sunset;

    // tiled background components
    public GameObject bgTile;
    public GameObject tileBase;
    public GameObject tileRain;
    public GameObject tileLightning;

    // fog sprites
    public List<Sprite> fogSprites;
    // threshold constants for how much fog to display
    private List<int> fogLevels = new List<int> { 5, 6, 7, 8, 9, 10, 11, 12, 13, 16, 18, 20, 23, 26, 29, 32 };
    // track if there is an ongoing fog transition
    private bool isFogFading = false;

    private RunManager runManager;

    // Start is called before the first frame update
    void Start()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        Debug.Assert(fogSprites.Count == fogLevels.Count);
    }

    // Update is called once per frame
    void Update()
    {
        RunState runState = runManager.runState;
        EmotionState e = runState.emotions;
        // change the static background based on the time of day
        Sprite newStaticBG = cloudy;
        if (runState.timeSteps > 0)
        {
            newStaticBG = sunset;
        }
        TransitionStaticBG(staticBase.GetComponent<Image>(), newStaticBG);
        // rain if sad
        tileRain.SetActive(e.despair > 10);
        // lightning if anxious
        tileLightning.SetActive(e.anxiety > 10);
        // change fogginess based on total emotion level
        int s = e.GetSum();
        int i = fogLevels.Count - 1;
        while (i > 0 && s < fogLevels[i])
        {
            i--;
        }
        if (!isFogFading)
        {
            TransitionFog(tileBase.GetComponent<SpriteRenderer>(), fogSprites[i]);
        }
    }

    void TransitionStaticBG(Image image, Sprite newSprite, float duration = 1f)
    {
        if (image.sprite != newSprite)
        {
            // spawn a fading out version of the previous image
            GameObject clone = Instantiate(image.gameObject, image.gameObject.transform.parent);
            StartCoroutine(FadeOutAndDestroy(clone.GetComponent<Image>(), duration));
            // switch to the new sprite in the original gameobject
            image.sprite = newSprite;
        }
    }

    void TransitionFog(SpriteRenderer sr, Sprite newSprite, float duration = .1f)
    {
        if (sr.sprite != newSprite)
        {
            // spawn a fading out version of the previous image
            GameObject clone = Instantiate(sr.gameObject, sr.gameObject.transform.parent);
            StartCoroutine(FadeOutAndDestroyFog(clone.GetComponent<SpriteRenderer>(), duration));
            // switch to the new sprite in the original gameobject
            sr.sprite = newSprite;
            sr.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);
            StartCoroutine(FadeIn(sr, duration));
        }
    }

    // used for the static backgrounds
    IEnumerator FadeOutAndDestroy(Image image, float duration)
    {
        const float deltaAlpha = .1f;
        for (float alpha = 1; alpha > 0; alpha -= deltaAlpha)
        {
            image.color = new Color(1f, 1f, 1f, alpha);
            yield return new WaitForSeconds(duration * deltaAlpha);
        }
        Destroy(image.gameObject);
    }

    // for some reason fade in only works on sprite renderers. this overall is a shitshow
    IEnumerator FadeIn(SpriteRenderer sr, float duration)
    {
        const float deltaAlpha = .1f;
        for (float alpha = 0; alpha < 1; alpha += deltaAlpha)
        {
            sr.color = new Color(1f, 1f, 1f, alpha);
            yield return new WaitForSeconds(duration * deltaAlpha);
        }
    }

    IEnumerator FadeOutAndDestroyFog(SpriteRenderer sr, float duration)
    {
        isFogFading = true;
        const float deltaAlpha = .1f;
        for (float alpha = 1; alpha > 0; alpha -= deltaAlpha)
        {
            sr.color = new Color(1f, 1f, 1f, alpha);
            yield return new WaitForSeconds(duration * deltaAlpha);
        }
        Destroy(sr.gameObject);
        isFogFading = false;
    }

}
