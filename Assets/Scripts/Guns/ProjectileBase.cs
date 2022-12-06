using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timeToLive = 2f;
    public int damageAmount = 10;
    public float bulletSpeed = 50f;

    public GameObject bullet;

    [Header("VFX")]
    public ParticleSystem shootVFX;
    public ParticleSystem hitVFX;

    [Header("Audio")]
    public AudioSource source;

    private string playerTag = "Player";

    private void Awake()
    {
        if(shootVFX!= null)
            shootVFX.Play();
        Destroy(gameObject, timeToLive);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(playerTag))
            return;

        /*var enemy = other.transform.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.Damage(damageAmount);
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
        }*/
    }

    private void OnHitDestroy(float timeToDestroy = 0)
    {
        if (source != null && source.clip != null)
            source.Play();
        Destroy(gameObject, timeToDestroy);
    }
}