using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBase : MonoBehaviour
{
    public float timeToLive = 2f;
    public int damageAmount = 10;
    public float bulletSpeed = 50f;

    public GameObject bullet;
    private Vector3 _targetPosition;

    [Header("VFX")]
    public ParticleSystem shootVFX;
    public ParticleSystem hitVFX;

    [Header("Audio")]
    public AudioSource source;

    private string enemyTag = "Enemy";

    private void Awake()
    {
        if (shootVFX != null)
            shootVFX.Play();
        Destroy(gameObject, timeToLive);
        _targetPosition = Vector3.zero;
    }

    public void SetTarget(Vector3 TargetPosition)
    {
        _targetPosition = TargetPosition;
    }

    private void Update()
    {
        if (_targetPosition == Vector3.zero)
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime * bulletSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(enemyTag))
            return;

        var damageable = other.transform.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.Damage(damageAmount);
            if (hitVFX != null)
            {
                hitVFX.Play();
                Destroy(bullet);
                OnHitDestroy(hitVFX.main.duration);
            }
            else
            {
                OnHitDestroy();
            }
        }
        else
        {
            OnHitDestroy();
        }
    }

    private void OnHitDestroy(float timeToDestroy = 0)
    {
        if (source != null && source.clip != null)
            source.Play();
        Destroy(gameObject, timeToDestroy);
    }
}