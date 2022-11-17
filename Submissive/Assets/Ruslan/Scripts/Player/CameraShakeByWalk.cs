using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeByWalk : MonoBehaviour
{

    public float Amount = 1f;
    public float Speed = 1f;

    private Vector3 _startPos;
    private float _distation;
    private Vector3 _rotation = Vector3.zero;

    void Start()
    {
        _startPos = transform.position;
    }

    public float RotateByWalk()
    {
        _distation += (transform.position - _startPos).magnitude;
        _startPos = transform.position;
        _rotation.z = Mathf.Sin(_distation * Speed) * Amount;
        return _rotation.z;
    }
}
