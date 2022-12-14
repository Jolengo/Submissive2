using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoorOnTrigger : MonoBehaviour
{
    public GameObject Wall;
    //public GameObject Door;
    public GameObject WallText;
    public GameObject DoorText;

    public GameObject FirstObject;
    private bool _isObjectActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerMovement>() && !_isObjectActivated)
            {
                Wall.SetActive(false);
                //Door.SetActive(true);
                WallText.SetActive(false);
                DoorText.SetActive(true);

                FirstObject.SetActive(true);
                _isObjectActivated = true;
            }
        }
    }
}
