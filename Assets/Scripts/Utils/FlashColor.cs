using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FlashColor : MonoBehaviour
{
    public Color damageColor = Color.red;
    public float flashDuration = 0.3f;
    public MeshRenderer meshRenderer;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public string propertyMaterial;

    private Tween _currentTween;
    private Color _defaultColor;

    private void OnValidate()
    {
        if (meshRenderer == null)
            meshRenderer = GetComponent<MeshRenderer>();
        if (skinnedMeshRenderer == null)
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    private void Start()
    {
        //_defaultColor = meshRenderer.material.GetColor(propertyMaterial);
    }

    public void Flash()
    {
        if( meshRenderer != null &&!_currentTween.IsActive())
            _currentTween = meshRenderer.material.DOColor(damageColor, propertyMaterial, flashDuration).SetLoops(2, LoopType.Yoyo);
        
        if (skinnedMeshRenderer != null && !_currentTween.IsActive())
            _currentTween = skinnedMeshRenderer.material.DOColor(damageColor, propertyMaterial, flashDuration).SetLoops(2, LoopType.Yoyo);
    }
}
