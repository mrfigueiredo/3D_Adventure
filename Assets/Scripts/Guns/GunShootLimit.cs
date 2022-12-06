using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunShootLimit : GunBase
{
    public List<UIGunUpdater> uiGunUpdaters;
    public int clipSize = 5;
    public float timeToRecharge = 1f;

    private bool _reloading = false;
    private float _currentShoots;
    private float _timeReloading;


    private void Start()
    {
        _currentShoots = clipSize;
    }

    private void Awake()
    {
        GetAllUIs();
    }

    protected override IEnumerator ShootAction()
    {
        if (_reloading)
            yield break;

        while (true)
        {
            if (_currentShoots <= 0)
            {
                CheckReload();
                yield break;
            }
            else if (_currentShoots > 0)
            {
                Shoot();
                _currentShoots--;
                UpdateUI();
                CheckReload();
                yield return new WaitForSeconds(timeBetweenShoots);
            }
        }
    }

    private void CheckReload()
    {
        if (_currentShoots <= 0)
        {
            CancelShoot();
            StartReload();
        }
    }

    private void StartReload()
    {
        _reloading = true;
        StartCoroutine(ReloadCoroutine());
    }

    IEnumerator ReloadCoroutine()
    {
        _timeReloading = 0;
        while (_timeReloading < timeToRecharge)
        {
            _timeReloading += Time.deltaTime;
            uiGunUpdaters.ForEach(i => i.UpdateValue(_timeReloading/timeToRecharge));
            yield return new WaitForEndOfFrame();
        }

        _currentShoots = clipSize;
        _reloading = false;
    }

    private void UpdateUI()
    {
        uiGunUpdaters.ForEach(i => i.UpdateValue(clipSize, _currentShoots));
    }

    private void GetAllUIs()
    {
        uiGunUpdaters = GameObject.FindObjectsOfType<UIGunUpdater>().ToList();
    }
}
