using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiHealthUpdater : MonoBehaviour
{
    public Slider uiSlider;

    [Header("Animation")]
    public float duration = .1f;
    public Ease ease = Ease.Linear;

    private Tween _currentTween;
    private void OnValidate()
    {
        if (uiSlider == null)
        {
            uiSlider = GetComponent<Slider>();
        }
    }

    public void SetMaxLife(float maxLife)
    {
        uiSlider.maxValue = maxLife;
    }

    public void UpdateValue(float f)
    {
        uiSlider.value = f;
    }

    public void UpdateValue(float max, float current)
    {
        if (_currentTween != null)
            _currentTween.Kill();

        _currentTween = uiSlider.DOValue(current / max, duration).SetEase(ease);
    }
}
