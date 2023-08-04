using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow_Trail : MonoBehaviour
{

    public CharacterController playerController;
    public ParticleSystem snowVFX;
    // Start is called before the first frame update

    private ParticleSystem.EmissionModule emission;

    void Start()
    {
            emission = snowVFX.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.isGrounded)
        {
            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
    }
}
