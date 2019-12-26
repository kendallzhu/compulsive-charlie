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

    public Sprite morning;
    public Sprite midday;
    public Sprite sunset;
    public Sprite night;

    // tiled background components
    public GameObject bgTile;
    public GameObject tileBase;
    public GameObject tileRain;
    public GameObject tileLightning;

    // background music sources
    public AudioSource rainAudio;
    public AudioSource thunderAudio;
    public AudioSource fireAudio;
    private const float fadeInDuration = 1f;
    private const float fadeOutDuration = 3f;
    // volume is capped by constant * emotion level
    private const float maxVolumeFactor = .4f / 20;

    // fog sprites
    public List<Sprite> fogSprites;
    // threshold constants for how much fog to display
    private List<int> fogLevels = new List<int> { 5, 6, 7, 8, 9, 10, 11, 12, 13, 16, 18, 20, 23, 26, 29, 32 };
    // track if there is an ongoing fog transition
    private bool isFogFading = false;

    // lightning sprites
    public List<Sprite> lightningSprites;

    // fire sprites
    public GameObject firePrefab;
    private int numFirePlumes;

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
        Sprite newStaticBG = morning;
        if (runState.timeSteps > 3)
        {
            newStaticBG = midday;
        }
        if (runState.timeSteps > 6)
        {
            newStaticBG = sunset;
        }
        if (runState.timeSteps > 8)
        {
            newStaticBG = night;
        }
        TransitionStaticBG(staticBase.GetComponent<Image>(), newStaticBG);
        
        // rain if sad
        if (e.despair >= 10)
        {
            tileRain.SetActive(true);
            rainAudio.volume += Time.deltaTime / fadeOutDuration;
            rainAudio.volume = Mathf.Min(rainAudio.volume, maxVolumeFactor * e.despair);
        } else
        {
            tileRain.SetActive(false);
            rainAudio.volume -= Time.deltaTime / fadeOutDuration;
        }
        Color transparent = new Color(1, 1, 1, (float)e.despair / 20f);
        tileRain.GetComponent<SpriteRenderer>().color = transparent;
        // lightning if anxious
        if (e.anxiety >= 10)
        {
            FlashLightning(.5f, Mathf.Min(0, (20f - e.anxiety) / 5f));
            thunderAudio.volume += Time.deltaTime / fadeInDuration;
            thunderAudio.volume = Mathf.Min(thunderAudio.volume, maxVolumeFactor * e.anxiety);
        } else
        {
            thunderAudio.volume -= Time.deltaTime / fadeOutDuration;
        }
        // fire if frustrated
        if (e.frustration >= 10)
        {
            int maxPlumes = e.frustration / 4;
            SpawnFire(runState.CurrentActivityPlatform(), maxPlumes);
            fireAudio.volume += Time.deltaTime / fadeInDuration;
            fireAudio.volume = Mathf.Min(fireAudio.volume, maxVolumeFactor * e.frustration);
        } else
        {
            fireAudio.volume -= Time.deltaTime / fadeOutDuration;
        }
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

    // flash lightning in a random X position on screen
    void FlashLightning(float duration, float wait)
    {
        if (staticOverlay.transform.childCount < 1)
        {
            Vector3 pos = new Vector3(Random.Range(0, 700), 0, 0);
            GameObject bolt = Instantiate(staticOverlay, pos, Quaternion.identity, staticOverlay.transform);
            bolt.GetComponent<Image>().sprite = lightningSprites[0];
            bolt.transform.localPosition = pos;
            StartCoroutine(FadeOutAndDestroy(bolt.GetComponent<Image>(), duration, wait));
        }
    }

    // spawn random plumes of fire on the platform
    void SpawnFire(ActivityPlatform platform, int maxPlumes)
    {
        if (numFirePlumes < maxPlumes)
        {
            numFirePlumes++;
            // random x position along the platform
            Vector3 pos = new Vector3(Random.Range(0, platform.length), 0, 0);
            GameObject plume = Instantiate(firePrefab, pos, Quaternion.identity, platform.transform);
            plume.transform.localPosition = pos;
            // random size
            float sizeFactor = Random.Range(0.5f, 1f);
            plume.transform.localScale = new Vector3(sizeFactor, sizeFactor, sizeFactor);
            plume.name = "FirePlume";
            StartCoroutine(FadeOutAndDestroyFire(plume.GetComponent<SpriteRenderer>(), Random.Range(1, 3f)));
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
    IEnumerator FadeOutAndDestroy(Image image, float duration, float wait = 0)
    {
        const float deltaAlpha = .1f;
        for (float alpha = 1; alpha > 0; alpha -= deltaAlpha)
        {
            image.color = new Color(1f, 1f, 1f, alpha);
            yield return new WaitForSeconds(duration * deltaAlpha);
        }
        image.color = new Color(1f, 1f, 1f, 0);
        yield return new WaitForSeconds(wait);
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

    IEnumerator FadeOutAndDestroyFire(SpriteRenderer sr, float duration = 1f)
    {
        const float deltaAlpha = .1f;
        for (float alpha = 1; alpha > 0; alpha -= deltaAlpha)
        {
            sr.color = new Color(1f, 1f, 1f, alpha);
            yield return new WaitForSeconds(duration * deltaAlpha);
        }
        Destroy(sr.gameObject);
        numFirePlumes--;
    }

}
