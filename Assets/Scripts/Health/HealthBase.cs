using System;
using System.Collections;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    public float startLife = 100f;
    public bool destroyOnKill = false;
    public float _currentLife;
    public float damageFactor = 1f;

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
        _currentLife -= damage*damageFactor;
        
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

    public void ChangeDamageFactor(float damageFactor, float duration)
    {
        StartCoroutine(ChangeDamageFactorCoroutine(damageFactor, duration));
    }
    
    private IEnumerator ChangeDamageFactorCoroutine(float damageFactor, float duration)
    {
        this.damageFactor = damageFactor;
        yield return new WaitForSeconds(duration);
        this.damageFactor = 1f;
    }
}
