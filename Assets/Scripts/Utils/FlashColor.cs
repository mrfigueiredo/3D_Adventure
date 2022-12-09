using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FlashColor : MonoBehaviour
{
    public Color damageColor = Color.red;
    public float flashDuration = 0.3f;
    public MeshRenderer meshRenderer;
    public string propertyMaterial;

    private Tween _currentTween;
    private Color _defaultColor;

    private void Start()
    {
        _defaultColor = meshRenderer.material.GetColor(propertyMaterial);
    }

    public void Flash()
    {
        if(!_currentTween.IsActive())
            _currentTween = meshRenderer.material.DOColor(damageColor, propertyMaterial, flashDuration).SetLoops(2, LoopType.Yoyo);
    }
}
