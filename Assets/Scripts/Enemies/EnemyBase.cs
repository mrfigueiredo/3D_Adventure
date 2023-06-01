using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animation;
using DG.Tweening;

public class EnemyBase : HealthBase
{
    public float damage = 50f;
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

    protected override void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        base.OnDamage += OnDamageCB;
        base.OnKill += OnKillCB;
        if (spawnWithAnimation)
            spawnAnimation();
    }
    public void OnDamageCB(HealthBase healthBase)
    {
 
        if (flashColor != null)
            flashColor.Flash();

        if (damageVFX != null)
            damageVFX.Play();
    }

    protected virtual void OnKillCB(HealthBase healthBase)
    {
        PlayAnimationByTrigger(AnimationType.DEATH);
        collider.enabled = false;
        if (hasDeathAnimation)
            Destroy(gameObject, timeToDestroyOnKill);
        else
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerBase player = collision.transform.GetComponent<PlayerBase>();
        if(player != null)
        {
            player.Damage(damage);
        }
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
