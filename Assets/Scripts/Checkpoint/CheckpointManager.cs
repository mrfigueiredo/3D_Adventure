using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckpointManager : Singleton<CheckpointManager>
{
    public int lastCheckpointKey = 0;
    public List<CheckpointBase> checkpoints;

    private CheckpointBase lastCheckpoint;
    public Vector3 playerInitialPos;

    private void Start()
    {
        playerInitialPos = FindObjectOfType<PlayerBase>().transform.position;
        checkpoints = new List<CheckpointBase>();
        GetAllCheckpoints();
    }

    private void GetAllCheckpoints()
    {
        checkpoints = FindObjectsOfType<CheckpointBase>().ToList();
    }

    public void SaveCheckpoint(CheckpointBase checkpoint)
    {
        DisableActiveCheckpoint();
        lastCheckpointKey = checkpoint.key;
        lastCheckpoint = checkpoint;
    }

    public void DisableActiveCheckpoint()
    {
        lastCheckpoint?.DeactivateCheckpoint();
    }

    public Vector3 GetPositionToRespawnPlayer()
    {
        if(lastCheckpoint != null)
            return lastCheckpoint.transform.position;
        else
        {
            return playerInitialPos;
        }
    }
}
