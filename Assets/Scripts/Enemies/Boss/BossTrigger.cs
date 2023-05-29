using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boss;

public class BossTrigger : MonoBehaviour
{
    public GameObject bossGO;
    public BossBase boss;
    public string TagToActivate = "Player";
    private bool _isStarted = false;

    void Start()
    {
        _isStarted = false;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagToActivate) && !_isStarted)
        {
            boss.gameObject.SetActive(true);
            boss.SwitchState(BossActions.INIT);
            _isStarted = true;
        }
    }
}
