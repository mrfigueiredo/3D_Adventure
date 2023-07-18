using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBase : MonoBehaviour
{
    public Animator animator;
    public string triggerOpen = "Open";
    public KeyCode keyOpen = KeyCode.E;
    
    [Header("Feedback")]
    public GameObject feedbackVisual;
    public float tweenDuration = 1f;
    public Ease tweenEase = Ease.OutBack;
    private Vector3 _startScale;

    [Header("Item")]
    public ContainerItemBase item;

    private bool _isOpen;

    private void Start()
    {
        HideNotification();
        _startScale = feedbackVisual.transform.localScale;
        _isOpen = false;
    }

    public void OpenContainer()
    {
        animator.SetTrigger(triggerOpen);
        HideNotification();
        _isOpen = true;
    }

    public void SpawnItem()
    {
        item.ShowItem();
        Invoke(nameof(CollectItem), 1f);
    }

    public void CollectItem()
    {
        item.Collect();
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerBase player = other.GetComponent<PlayerBase>();
        if(player!=null && !_isOpen)
        {
            ShowNotification();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        PlayerBase player = other.GetComponent<PlayerBase>();
        if (player != null)
        {
            HideNotification();
        }
    }

    private void ShowNotification()
    {
        feedbackVisual.SetActive(true);
        feedbackVisual.transform.localScale = Vector3.zero;
        feedbackVisual.transform.DOScale(_startScale, tweenDuration);
    }

    private void HideNotification()
    {
        feedbackVisual.transform.DOScale(Vector3.zero, tweenDuration);
        feedbackVisual.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(keyOpen) && feedbackVisual.activeSelf && !_isOpen)
        {
            OpenContainer();
        }
    }
}
