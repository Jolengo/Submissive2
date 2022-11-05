using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorEvents : MonoBehaviour
{
    public Camera PlayerCamera;
    public HingeJoint DoorJoint;

    public Transform PlayerPosition;

    public AudioSource Open;
    public AudioSource Close;

    public float TimeToClose = 10f;
    public float OpeningDistance = 10f;

    private bool _isOpen = false;
    private bool _isAbleToOpen = true;
    private float _timeOpened = 0f;
    private Vector3 _doorPosition;
    private Vector3 _playerPosition;
    private RaycastHit _hit;
    private float _startDoorAngle;

    private void Start()
    {
        _startDoorAngle = DoorJoint.gameObject.transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        if (_isOpen)
        {
            _timeOpened += Time.deltaTime;
            if (_timeOpened >= TimeToClose)
            {
                _isOpen = false;
                _timeOpened = 0f;
            }
        }

        DoorOpening();
        IsAbleToOpenByDistance();
        OpenTheDoor();
        DoorOpener();
    }

    public void OpenTheDoor()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hit))
        {
            if (_hit.collider.GetComponentInParent<HingeJoint>() &&
                Input.GetMouseButtonDown(0) &&
                _isAbleToOpen)
            {
                if (_isOpen)
                {
                    _isOpen = false;
                    Close.PlayDelayed(0.2f);
                    _timeOpened = 0f;
                }
                else
                {
                    _isOpen = true;
                    Open.Play();
                }
            }
        }
    }

    public void DoorOpener()
    {
        JointSpring doorSpring = DoorJoint.spring;

        if (_isOpen)
        {
            doorSpring.targetPosition = DoorJoint.limits.max;
        }
        else
        {
            doorSpring.targetPosition = DoorJoint.limits.min;
        }

        DoorJoint.spring = doorSpring;
    }

    public void DoorOpening()
    {
        float y = Mathf.Round(DoorJoint.gameObject.transform.rotation.eulerAngles.y - _startDoorAngle);
        bool isTrigger = DoorJoint.gameObject.GetComponent<Collider>().isTrigger;

        if (y == DoorJoint.limits.min || y == DoorJoint.limits.max)
        {
            isTrigger = false;
        }
        else
        {
            isTrigger = true;
        }

        DoorJoint.gameObject.GetComponent<Collider>().isTrigger = isTrigger;
    }

    public void IsAbleToOpenByDistance()
    {
        _doorPosition = DoorJoint.GetComponent<Transform>().position;
        _playerPosition = PlayerPosition.position;

        float distance;
        distance = Vector3.Distance(_doorPosition, _playerPosition);
        if (distance >= OpeningDistance)
            _isAbleToOpen = false;
        else
            _isAbleToOpen = true;
    }
}