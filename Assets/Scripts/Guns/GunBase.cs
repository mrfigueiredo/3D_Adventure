using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectileBase;
    public Transform shootPosition;
    public float timeBetweenShoots = .5f;

    private Coroutine _currentShooting;

    protected virtual IEnumerator ShootAction()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }

    public virtual void Shoot()
    {
        var projectile = Instantiate(projectileBase);
        projectile.transform.position = shootPosition.position;
        projectile.transform.rotation = shootPosition.rotation;
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
