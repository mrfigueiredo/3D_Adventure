using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PPManager : Singleton<PPManager>
{
    public PostProcessVolume volume;
    
    private Vignette _vignette;
    public Color vignetteOnHitColor = Color.red;
    public Color vignetteColor = Color.black;
    public float flashVignetteTime = 0.5f;

    public void Start()
    {
        Vignette temp; 
        if(volume.profile.TryGetSettings<Vignette>( out temp))
        {
            _vignette = temp;
        }
    }

    public void VignetteOnHit()
    {
        if (_vignette == null)
            return;
        StartCoroutine(FlashVignetteColor());
    }

    private IEnumerator FlashVignetteColor()
    {
        float time = 0;
        ColorParameter c = new ColorParameter();

        while(time < flashVignetteTime)
        {
            c.value = Color.Lerp(vignetteColor, vignetteOnHitColor, time / flashVignetteTime);

            _vignette.color.Override(c);

            yield return new WaitForEndOfFrame();

            time += Time.deltaTime;
        }

        time = 0;

        while (time < flashVignetteTime)
        {
            c.value = Color.Lerp(vignetteOnHitColor, vignetteColor,  time / flashVignetteTime);

            _vignette.color.Override(c);

            yield return new WaitForEndOfFrame();

            time += Time.deltaTime;
        }
    }
}
