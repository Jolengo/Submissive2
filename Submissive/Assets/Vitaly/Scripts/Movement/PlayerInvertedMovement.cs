using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvertedMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float runSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    private bool readyToJump;

    public bool _isRunning;

    [Header("Sounds")]
    public AudioSource _walkSound;
    public AudioSource _runSound;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask whatIsGround;
    private bool grounded;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        _isRunning = false;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        if (_isRunning == false)
            SpeedControl(moveSpeed);
        else if (_isRunning == true)
            SpeedControl(runSpeed);


        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Vertical");
        verticalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            Debug.Log("Space pressed");
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (_isRunning == false)
                _isRunning = true;
            else if (_isRunning == true)
                _isRunning = false;
        }
    }

    private void MovePlayer()
    {
        if (_isRunning == false)
            Walk();
        else if (_isRunning == true)
            Run();
    }

    private void Walk()
    {
        // просчитыватся направление движения
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;


        if (grounded)
        {
            // Если идёт - звук играет
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            if (!_walkSound.isPlaying && moveDirection.normalized * moveSpeed * 10f != new Vector3(0, 0, 0))
            {
                _walkSound.Play();
                _runSound.Stop();
            }
            // Если стоит - звук стопается
            else if (_walkSound.isPlaying && moveDirection.normalized * moveSpeed * 10f == new Vector3(0, 0, 0))
            {
                _walkSound.Stop();
                _runSound.Stop();
            }
        }
        // Если не на земле и звук был - больше звук не играет
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            if (_walkSound.isPlaying)
            {
                _walkSound.Stop();
                _runSound.Stop();
            }
        }
    }

    private void Run()
    {
        // просчитыватся направление движения
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;


        if (grounded)
        {
            // Если идёт - звук играет
            rb.AddForce(moveDirection.normalized * runSpeed * 10f, ForceMode.Force);
            if (!_runSound.isPlaying && moveDirection.normalized * runSpeed * 10f != new Vector3(0, 0, 0))
            {
                _runSound.Play();
                _walkSound.Stop();

            }
            // Если стоит - звук стопается
            else if (_runSound.isPlaying && moveDirection.normalized * runSpeed * 10f == new Vector3(0, 0, 0))
            {
                _runSound.Stop();
                _walkSound.Stop();
            }
        }
        // Если не на земле и звук был - больше звук не играет
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * runSpeed * 10f * airMultiplier, ForceMode.Force);
            if (_runSound.isPlaying)
            {
                _runSound.Stop();
                _walkSound.Stop();
            }
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void SpeedControl(float speed)
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
