using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Movement")]
    public Animator animator;
    public CharacterController characterController;
    public KeyCode runningKey = KeyCode.LeftShift;

    public float speed = 25f;
    public float runningMultiplier = 2f;
    public float rotationSpeed = 15f;
    public float jumpSpeed = 25f;
    public float gravity = 9.8f;

    private bool _isWalking = false;
    private float _verticalSpeed = 0f;
    private float _verticalInput;
    private Vector3 _moveInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);
        _verticalInput = Input.GetAxis("Vertical");

        _isWalking = _verticalInput != 0;
        
        _moveInput = transform.forward * _verticalInput;

        if(_isWalking && Input.GetKey(runningKey))
        {
            _moveInput *= runningMultiplier;
            animator.speed = runningMultiplier;
        }
        else
        {
            animator.speed = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            _verticalSpeed = jumpSpeed;
        }

        _verticalSpeed -= gravity * Time.deltaTime;

        _moveInput.y = _verticalSpeed;

        characterController.Move(_moveInput * speed * Time.deltaTime);

        animator.SetBool("Run", _isWalking);

    }
}
