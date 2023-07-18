using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Inventory;
using static UnityEditor.Progress;

public class ContainerItem_Coin : ContainerItemBase
{
    public ITEMTYPE type = ITEMTYPE.COIN;
    public int coinsAmount = 10;
    public GameObject coinObject;
    public float tweenDuration = 0.2f;
    public Ease tweenEase = Ease.OutBack;

    [Header("Collect Animation")]
    public float collectDuration = .5f;
    public float collectHeight = 2f;


    private List<GameObject> coinsList = new List<GameObject>();
    private void CreateItems()
    {
        for(int i = 0; i < coinsAmount; i++)
        {
            var item = Instantiate(coinObject);
            item.transform.position = transform.position;
            item.transform.DOScale(0, tweenDuration).SetEase(tweenEase).From();
            coinsList.Add(item);
        }
    }

    public override void Collect()
    {
        StartCoroutine(CollectCoin());
    }

    IEnumerator CollectCoin()
    {
        foreach (var item in coinsList)
        {
            item.transform.DOMoveY(collectHeight, collectDuration).SetRelative();
            item.transform.DOScale(0, collectDuration / 2).SetDelay(collectDuration / 2);
            ItemManager.Instance.AddItemByType(type);
            yield return new WaitForSeconds(0.25f);
        }
    }

    public override void ShowItem()
    {
        CreateItems();
    }

}
