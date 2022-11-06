using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWallOnTrigger : MonoBehaviour
{
    public GameObject Wall;

    private bool _isObjectActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerMovement>() && !_isObjectActivated)
            {
                Wall.SetActive(true);
                _isObjectActivated = true;
            }
        }
    }
}
