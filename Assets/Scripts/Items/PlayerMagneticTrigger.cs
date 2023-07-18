using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagneticTrigger : MonoBehaviour
{
    private PlayerBase player;

    private void Awake()
    {
        player = GetComponentInParent<PlayerBase>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectableBase cb = other.GetComponent<CollectableBase>();
        if(cb != null)
        {
            var mi = cb.transform.gameObject.AddComponent<MagneticItem>();
            mi.player = player;
        }
    }
}
