using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour
{
    public int key = 01;
    public string checkpointKey = "checkpointKey";
    public string PlayerTag = "Player";

    public string EmissionColor = "_EmissionColor";
    public MeshRenderer meshRenderer;
    public GameObject textObject;

    public Color activeColor = Color.white;
    public Color unactiveColor = Color.grey;
    
    private bool _isActive = false;

    private void OnTriggerEnter(Collider other)
    {

        if (!_isActive && other.gameObject.tag == PlayerTag)
        {
            CheckCheckpoint();
        }

    }

    private void CheckCheckpoint()
    {
        ActivateCheckpoint();
    }

    private void ActivateCheckpoint()
    {
        meshRenderer.material.SetColor(EmissionColor, activeColor);
        SaveCheckpoint();
        CheckpointManager.Instance.SaveCheckpoint(this);
        textObject.SetActive(true);
    }

    public void DeactivateCheckpoint()
    {
        meshRenderer.material.SetColor(EmissionColor, unactiveColor);
        _isActive = false;
        textObject.SetActive(false);
    }

    private void SaveCheckpoint()
    {
        PlayerPrefs.SetInt(checkpointKey, key);
        _isActive = true;
    }
}
