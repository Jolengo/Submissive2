using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsOnTrigger : MonoBehaviour
{
    public GameObject FirstObject;

    private bool _isObjectActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody && !_isObjectActivated)
        {
            FirstObject.SetActive(true);
            _isObjectActivated = true;
        }
    }
}
