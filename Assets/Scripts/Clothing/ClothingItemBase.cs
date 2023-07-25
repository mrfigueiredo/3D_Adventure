using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Clothing;
public class ClothingItemBase : MonoBehaviour
{
    public ClothType clothType;
    public ParticleSystem vfxPrefab;
    public string tagToCompare = "Player";
    public float duration = 10f;

    [Header("Audio")]
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tagToCompare))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
        ClothesChanger.Instance.ChangeTexture(ClothingManager.Instance.GetByType(clothType), duration);
    }

    protected virtual void OnCollect()
    {
        if (vfxPrefab != null)
            vfxPrefab.Play();

        if (audioSource != null)
            audioSource.Play();    
    }


}
