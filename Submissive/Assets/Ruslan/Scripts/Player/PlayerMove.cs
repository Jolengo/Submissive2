using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController Controller;

    public float WalkSpeed = 6f;
    public float RunSpeed = 10f;

    public float Gravity = -9.81f;
    public float JumpHeight = 3f;
    public float MaxBoost = -2f;
    public float GroundDistance = 0.4f;

    public float ShakeDelay = 0.1f;
    public float ShakeDuration = 0.025f;

    public CameraShake CameraShake;

    public Transform GroundCheck;
    public LayerMask GroundMask;

    private Vector3 _velocity;
    public bool IsGrounded;
    private float _height;

    private void Start()
    {
        _height = Controller.height;
    }

    void Update()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);   

        if (IsGrounded && _velocity.y < 0f)
        {
            _velocity.y = MaxBoost;  
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Debug.Log("x = " + x.ToString());
        Debug.Log("z = " + z.ToString());

        Vector3 move = transform.right * x + transform.forward * z;        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Controller.Move(move * RunSpeed * Time.deltaTime);
        }
        else
        {
            Controller.Move(move * WalkSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            _velocity.y = Mathf.Sqrt(JumpHeight * MaxBoost * Gravity);
            Invoke("CameraShakeOnJump", ShakeDelay);
        }

        _velocity.y += Gravity * Time.deltaTime;
        Controller.Move(_velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Controller.height = _height / 2;
        }
        else
        {
            Controller.height = _height;
        }
    }

    public void CameraShakeOnJump()
    {
        CameraShake.shakeDuration = ShakeDuration;
    }
}
