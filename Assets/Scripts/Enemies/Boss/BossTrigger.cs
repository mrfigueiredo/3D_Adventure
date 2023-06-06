using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boss;
using Cinemachine;

public class BossTrigger : MonoBehaviour
{
    public GameObject bossGO;
    public BossBase boss;
    public CinemachineVirtualCamera bossCamera;
    public string TagToActivate = "Player";
    private bool _isStarted = false;

    void Start()
    {
        _isStarted = false;
        bossCamera.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagToActivate) && !_isStarted)
        {
            boss.gameObject.SetActive(true);
            boss.SwitchState(BossActions.INIT);
            _isStarted = true;
            bossCamera.enabled = true;
            ScreenShaker.Instance.SetNewCamera(bossCamera);
        }
    }
}
