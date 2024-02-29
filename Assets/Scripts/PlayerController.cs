using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    private Vector3 _moveVectror;
    private float _fallVelocity = 0;

    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Movement
        _moveVectror = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVectror += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVectror -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVectror += transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVectror -= transform.forward;
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement
        _characterController.Move(_moveVectror * speed * Time.fixedDeltaTime);

        // fall and jump
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        // Stop fall if on the ground
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
