using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyBase
{

    public EnemyGun gunBase;
    public float distanceToShoot = 50f;

    private PlayerBase _player;
    private bool _isShooting = false;

    protected override void Init()
    {
        base.Init();
        _player = GameObject.FindObjectOfType<PlayerBase>();
        gunBase.SetPlayer(_player);

    }

    protected override void Awake()
    {
        base.Awake();
        _isShooting = false;
    }

    protected override void OnKillCB(HealthBase healthBase)
    {
        base.OnKillCB(healthBase);
        gunBase.CancelShoot();
    }

    protected void Update()
    {
        if(Vector3.Distance(_player.transform.position, this.transform.position) < distanceToShoot && !_isShooting)
        {
            this.transform.LookAt(_player.transform);
            gunBase.StartShoot();
            _isShooting = true;
        }
        else if (Vector3.Distance(_player.transform.position, this.transform.position) < distanceToShoot && _isShooting)
        {
            this.transform.LookAt(_player.transform);
        }
        else if (Vector3.Distance(_player.transform.position, this.transform.position) > distanceToShoot && _isShooting)
        {
            _isShooting = false;
            gunBase.CancelShoot();
        }

    }
}
