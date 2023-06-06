using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShaker : Singleton<ScreenShaker>
{
    public CinemachineVirtualCamera virtualCamera;
    public float baseFrequency = 2f;
    public float baseAmplitude = 2f;
    public float baseShakeTime = 0.5f;

    private float shakeTime = 0.5f;

    
    
    private CinemachineBasicMultiChannelPerlin noise;



    protected override void Awake()
    {
        base.Awake();
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void SetNewCamera(CinemachineVirtualCamera camera)
    {
        noise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake()
    {
        ShakeScreen(baseFrequency, baseAmplitude, baseShakeTime);
    }

    public void ShakeScreen(float frequency, float amplitude, float time)
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;

        shakeTime = time;
    }

    private void Update()
    {
        if(shakeTime > 0 )
        {
            shakeTime -= Time.deltaTime;
        }
        else
        {
            noise.m_AmplitudeGain = 0;
            noise.m_FrequencyGain = 0;
        }
    }
}
