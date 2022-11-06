using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoorOnTrigger : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Door;
    public GameObject WallText;
    public GameObject DoorText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerMovement>())
            {
                Wall.SetActive(false);
                Door.SetActive(true);
                WallText.SetActive(false);
                DoorText.SetActive(true);
            }
        }
    }
}
