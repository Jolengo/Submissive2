using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInterract : MonoBehaviour
{

    public float ActivateDistance = 5f;

    private Camera _playerCamera;
    private DoorController _doorController;
    private Transform _playerPosition;

    private bool _isOpen = false;

    private void Start()
    {
        _playerCamera = FindObjectOfType<MouseLook>().GetComponent<Camera>();
    }

    void Update()
    {
        _playerPosition = FindObjectOfType<PlayerMove>().GetComponent<Transform>();

        Debug.Log(Vector3.Distance(transform.position, _playerPosition.position));

        RaycastHit hit;

        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponentInParent<DoorController>() 
                && Input.GetMouseButtonDown(0)
                && ActivateDistance >= Vector3.Distance(transform.position, _playerPosition.position))
            {
                _doorController = hit.collider.GetComponentInParent<DoorController>();
                if (!_isOpen)
                {
                    _doorController.Open();
                    _isOpen = true;
                }
                else
                {
                    _doorController.Close();
                    _isOpen = false;
                }
            }
        }
    }
}