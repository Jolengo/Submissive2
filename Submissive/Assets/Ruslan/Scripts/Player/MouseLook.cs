using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensevity = 500f;
    public float MouseXMin = -90f;
    public float MouseXMax = 90f;

    public Transform PlayerBody;
    public CameraShakeByWalk CameraShake;

    private float _xRotation = 0f;
    private float _isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (PlayerBody.GetComponent<PlayerMove>().IsGrounded)
            _isGrounded = 1f;
        else
            _isGrounded = 0f;

        float mouseX = Input.GetAxis("Mouse X") * MouseSensevity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensevity * Time.deltaTime;

        float _zRotation = CameraShake.RotateByWalk() * (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical")) * _isGrounded;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, MouseXMin, MouseXMax);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, _zRotation);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
