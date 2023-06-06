using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : HealthBase 
{
        
    [Header("FlashDamage")]
    public List<FlashColor> flashColor;

    [Header("Animaition")]
    public Animator animator;
    public string DeathTrigger = "Death";
    private bool _isAlive = true;
    public List<Collider> colliders;

    [Header("Respawn")]
    public string RespawnTrigger = "Revive";

    public UiHealthUpdater uiUpdater;

    void Start()
    {
        OnDamage += DamagePlayer;
        OnKill += OnKillPlayer;
        _isAlive = true;
        uiUpdater.SetMaxLife(startLife);
        uiUpdater.UpdateValue(_currentLife);
    }

    public void DamagePlayer(HealthBase health)
    {
        flashColor.ForEach( i => i.Flash());
        uiUpdater.UpdateValue(_currentLife);
        PPManager.Instance.VignetteOnHit();
        ScreenShaker.Instance.Shake();
    }

    private void OnKillPlayer(HealthBase health)
    {
        if (_isAlive)
        {
            _isAlive = false;
            colliders.ForEach(i => i.enabled = false);
            animator.SetTrigger(DeathTrigger);
            Invoke(nameof(Respawn), 4f);
        }
    }

    [NaughtyAttributes.Button]
    private void Respawn()
    {
        ResetLife();
        uiUpdater.UpdateValue(_currentLife);
        _isAlive = true;
        transform.position = CheckpointManager.Instance.GetPositionToRespawnPlayer();
        animator.SetTrigger(RespawnTrigger);

        Invoke(nameof(EnableColliders), .2f);
    }

    private void EnableColliders()
    {
        colliders.ForEach(i => i.enabled = true);
    }
}
