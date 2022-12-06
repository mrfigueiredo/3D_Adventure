using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotgun : GunShootLimit
{
    public int amountPerShoot = 4;
    public float angle = 15f;

    private int _shootIndex;
    private int _multi;
    public override void Shoot()
    {
        _multi = 0;

        if (amountPerShoot % 2 == 0)
        {

            for (_shootIndex = 0; _shootIndex < amountPerShoot; _shootIndex++)
            {
                if (_shootIndex % 2 == 0)
                {
                    _multi++;
                }

                var projectile = Instantiate(projectileBase, shootPosition);

                projectile.transform.localPosition = Vector3.zero;

                if (_multi == 1)
                    projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * ((_shootIndex % 2 == 0 ? angle : -angle)) / 2 * _multi;
                else
                    projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * ((_shootIndex % 2 == 0 ? angle : -angle)) * _multi;

                projectile.transform.parent = null;
            }
        }
        else
        {

            var projectileCenter = Instantiate(projectileBase, shootPosition);

            projectileCenter.transform.localPosition = Vector3.zero;
            projectileCenter.transform.localEulerAngles = Vector3.zero + Vector3.up;

            projectileCenter.transform.parent = null;

            for (_shootIndex = 1; _shootIndex < amountPerShoot; _shootIndex++)
            {
                if (_shootIndex % 2 != 0)
                {
                    _multi++;
                }

                var projectile = Instantiate(projectileBase, shootPosition);

                projectile.transform.localPosition = Vector3.zero;
                projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * ((_shootIndex % 2 == 0 ? angle : -angle)) * _multi;

                projectile.transform.parent = null;
            }
        }
    }
}
