using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public EnemyProjectileBase projectileBase;
    public Transform shootPosition;
    public float timeBetweenShoots = .5f;

    private Coroutine _currentShooting;
    private PlayerBase _player;

    public virtual void SetPlayer(PlayerBase player)
    {
        _player = player;
    }

    protected virtual IEnumerator ShootAction()
    {
        while (true)
        {
            Shoot(_player.transform.position);

            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }

    public virtual void Shoot(Vector3 Target)
    {
        var projectile = Instantiate(projectileBase);
        projectile.transform.position = shootPosition.position;
        projectile.transform.rotation = shootPosition.rotation;
        projectile.SetTarget(Target);
    }

    public virtual void ShootAtTarget(Vector3 Target)
    {
        var projectile = Instantiate(projectileBase);
        projectile.transform.position = shootPosition.position;
        projectile.transform.rotation = shootPosition.rotation;
        projectile.SetTarget(Target);
    }

    public void StartShoot()
    {
        CancelShoot();
        _currentShooting = StartCoroutine(ShootAction());
    }

    public void CancelShoot()
    {
        if (_currentShooting != null)
            StopCoroutine(_currentShooting);
    }
}
