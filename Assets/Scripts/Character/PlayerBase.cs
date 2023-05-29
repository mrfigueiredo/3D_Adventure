using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    public float startLife = 100f;

    
    [Header("FlashDamage")]
    public List<FlashColor> flashColor;

    private float _currentLife;

    void Start()
    {
        _currentLife = startLife;
    }

    public void Damage(float damage)
    {
        flashColor.ForEach( i => i.Flash());
        _currentLife -= damage;
    }

}
