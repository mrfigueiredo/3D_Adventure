using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Inventory;

public class Life : CollectableBase
{
    [Header("Animation")]
    public float idleAnimationLoopTime = 0.5f;
    public Ease idleAnimatonEase = Ease.OutBack;
    public Vector3 idleAnimationPulseScale = new Vector3(0.8f, 0.8f, 0.8f);
    public float collectAnimationDuration = 0.5f;
    public Ease collectAnimationEase = Ease.OutElastic;

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
            ItemManager.Instance?.AddItemByType(ITEMTYPE.LIFEPACK);
            StartCoroutine(CollectAnimation());
        }
    }

    IEnumerator CollectAnimation()
    {
        DOTween.Kill(transform);
        transform.DOScale(0, collectAnimationDuration).SetEase(collectAnimationEase);
        yield return new WaitForSeconds(1.5f*collectAnimationDuration);
        Destroy(gameObject);
    }

    private void IdleAnimation()
    {
        transform.DOScale(idleAnimationPulseScale, idleAnimationLoopTime).SetLoops(-1, LoopType.Yoyo).SetEase(idleAnimatonEase);
    }
}
