using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Inventory;

public class DestructibleItemBase : HealthBase
{
    public GameObject goPrefab;
    public float shakeDuration = .5f;
    public int shakeForce = 2;

    public Vector3 shakeVector = Vector3.zero;

    [Header("Reward")]
    public ITEMTYPE type = ITEMTYPE.COIN;
    public int rewardAmount = 4;
    public GameObject rewardPrefab;
    public float spawnDuration = .5f;
    public Ease spawnEase = Ease.OutBack;


    private Tween _tween;
    private int _amountSpawned;

    protected override void Awake()
    {
        base.Awake();
        OnDamage += Damage;
        OnKill += Kill;
        _amountSpawned = 0;
    }

    private void Damage(HealthBase hb)
    {
        
        if(_tween == null || !_tween.IsPlaying())
        {
            _tween = goPrefab.transform.DOShakeScale(shakeDuration, shakeVector, shakeForce);
            DropReward();
        }
        
    }

    private void Kill(HealthBase hb)
    {
        if (_amountSpawned < rewardAmount)
        {
            for (int i = _amountSpawned; i < rewardAmount; i++)
            {
                DropReward();
            }
        }
    }

    private void DropReward()
    {
        if (_amountSpawned < rewardAmount)
        {
            _amountSpawned++;
            var item = Instantiate(rewardPrefab);
            item.transform.position = transform.position;
            item.transform.rotation = Random.rotation;
            item.transform.DOScale(0, spawnDuration).SetEase(spawnEase).From();
        }
    }
}
