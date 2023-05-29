using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : EnemyBase
{
    [Header("Waypoints")]
    public GameObject[] waypoints;

    public float minDistance = 1f;
    public float speed = 5f;

    private int _index = 0;

    protected override void Init()
    {
        base.Init();
        transform.LookAt(waypoints[_index].transform.position);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[_index].transform.position) < minDistance)
        {
            _index++;
            if (_index >= waypoints.Length)
            {
                _index = 0;
            }
            transform.LookAt(waypoints[_index].transform.position);
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[_index].transform.position, Time.deltaTime * speed);        
    }
}
