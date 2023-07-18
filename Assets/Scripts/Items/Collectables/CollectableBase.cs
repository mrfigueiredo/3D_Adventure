using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;
public class CollectableBase : MonoBehaviour
{
    public ParticleSystem vfxPrefab;
    public string tagToCompare = "Player";
    public ITEMTYPE itemType;
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
    }

    protected virtual void OnCollect()
    {
        if (vfxPrefab != null)
            vfxPrefab.Play();

        if (audioSource != null)
            audioSource.Play();

        ItemManager.Instance?.AddItemByType(itemType);
    }
}
