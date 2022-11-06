using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectOnTrigger : MonoBehaviour
{
    public GameObject Object;

    private bool _isObjectActivated = false;
    private bool _isTrueTrack = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerMovement>() && !_isObjectActivated)
            {
                Object.SetActive(false);
                _isObjectActivated = true;
            }
        }
    }
}
