using System;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    public float startLife = 100f;
    public bool destroyOnKill = false;
    public float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    protected virtual void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        ResetLife();
    }

    protected void ResetLife()
    {
        _currentLife = startLife;
    }

    public void Damage(float damage)
    {
        _currentLife -= damage;
        
        OnDamage?.Invoke(this);

        if (_currentLife <= 0)
        {
            Kill();
        }
    }

    protected virtual void Kill()
    {
        OnKill?.Invoke(this);

        if(destroyOnKill)
            Destroy(gameObject);
    }

}
