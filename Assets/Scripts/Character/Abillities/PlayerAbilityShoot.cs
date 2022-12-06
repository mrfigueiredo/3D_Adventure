using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<GunBase> gunBases;
    public Transform gunPosition;

    private List<GunBase> _gunsAvailable;
    private GunBase _currentGun;

    protected override void Init()
    {
        base.Init();

        CreateGuns();

        EquipGun(0);

        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();

        inputs.Gameplay.EquipItem1.performed += cts => EquipGun(0);
        inputs.Gameplay.EquipItem1.canceled += cts => Unequip();

        inputs.Gameplay.EquipItem2.performed += cts => EquipGun(1);
        inputs.Gameplay.EquipItem2.canceled += cts => Unequip();
    }

    private void EquipGun(int index)
    {
        if (_currentGun != null)
            _currentGun.gameObject.SetActive(false);

        _currentGun = _gunsAvailable[index];
        _currentGun.gameObject.SetActive(true);
    }

    private void Unequip()
    {

    }

    private void CreateGuns()
    {
        _gunsAvailable = new List<GunBase>();

        foreach (var gun in gunBases)
        {
            var _gun = Instantiate(gun, gunPosition);
            _gun.transform.localPosition = _gun.transform.localEulerAngles = Vector3.zero;
            _gun.gameObject.SetActive(false);

            _gunsAvailable.Add(_gun);
        }
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
    }

    private void CancelShoot()
    {
        _currentGun.CancelShoot();
    }
}
