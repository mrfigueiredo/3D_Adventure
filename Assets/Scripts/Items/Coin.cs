using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Inventory;

public class Coin : CollectableBase
{
    [Header("Animation")]
    public float idleAnimationLoopTime = 0.5f;
    public Ease idleAnimatonEase = Ease.OutBack;

    private bool _collected = false;

    private void Awake()
    {
        IdleAnimation();
    }

    protected override void OnCollect()
    {
        if (!_collected)
        {
            _collected = true;
            base.OnCollect();
            StartCoroutine(CollectAnimation());
        }
    }

    IEnumerator CollectAnimation()
    {
        DOTween.Kill(transform);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void IdleAnimation()
    {
        transform.DORotate(new Vector3(0, 360, 0), idleAnimationLoopTime, RotateMode.LocalAxisAdd).SetEase(idleAnimatonEase).SetLoops(-1, LoopType.Incremental);
    }
}
