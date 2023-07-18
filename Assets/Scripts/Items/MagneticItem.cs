using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticItem : MonoBehaviour
{
    public float itemSpeed = 1f;
    public float accelerationFactor = 1f;
    public bool noDelay = false;
    public float delayToPlayer = 1f;

    public PlayerBase player;

    private float _currentTime;

    private void Start()
    {
        _currentTime = 0;
    }

    void Update()
    {
        if (_currentTime > delayToPlayer || noDelay)
        {
            itemSpeed += accelerationFactor;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * itemSpeed);
        }
        _currentTime += Time.deltaTime;
    }
}
