using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<GunBase> gunBases;
    public Transform gunPosition;

    private GunBase _selectedGun;
    private GunBase _currentGun;

    protected override void Init()
    {
        base.Init();

        _selectedGun = gunBases[0];

        CreateGun();

        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();

        inputs.Gameplay.EquipItem1.performed += cts => EquipGun1();
        inputs.Gameplay.EquipItem1.canceled += cts => Unequip();

        inputs.Gameplay.EquipItem2.performed += cts => EquipGun2();
        inputs.Gameplay.EquipItem2.canceled += cts => Unequip();
    }

    private void EquipGun1()
    {
        _selectedGun = gunBases[0];
        CreateGun();
    }

    private void EquipGun2()
    {
        _selectedGun = gunBases[1];
        CreateGun();
    }

    private void Unequip()
    {

    }

    private void CreateGun()
    {
        if (_currentGun != null)
            Destroy(_currentGun);
        _currentGun = Instantiate(_selectedGun, gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
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
