using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animation;
using DG.Tweening;

public class EnemyBase : MonoBehaviour, IDamageable
{
    public float startLife = 10f;
    public Collider collider;
    public FlashColor flashColor;
    public ParticleSystem damageVFX;        

    [Header("Start Animation")]
    public float spawnAnimationDuration = 0.2f;
    public Ease spawnAnimationEase = Ease.OutBack;
    public bool spawnWithAnimation = true;
    public bool hasDeathAnimation = true;
    public float timeToDestroyOnKill = 1f;

    [SerializeField] private AnimationBase _animationBase;
    private float _currentLife;

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        ResetLife();
        if (spawnWithAnimation)
            spawnAnimation();
    }

    private void ResetLife()
    {
        _currentLife = startLife;
    }

    public void OnDamage(float damage)
    {
        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }

        if (flashColor != null)
            flashColor.Flash();

        if (damageVFX != null)
            damageVFX.Play();
    }

    protected virtual void Kill()
    {
        PlayAnimationByTrigger(AnimationType.DEATH);
        OnKill();
    }

    protected virtual void OnKill()
    {
        collider.enabled = false;
        if (hasDeathAnimation)
            Destroy(gameObject, timeToDestroyOnKill);
        else
            Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        OnDamage(damage);
    }

    #region ANIMATIONS
    private void PlayAnimationByTrigger(AnimationType animationType)
    {
        _animationBase.PlayAnimationType(animationType);
    }
    private void spawnAnimation()
    {
        transform.DOScale(0, spawnAnimationDuration).SetEase(spawnAnimationEase).From();
    }


    #endregion
}
