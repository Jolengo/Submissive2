using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    public GameObject Text;
    public Camera PlayerCamera;

    private void OnTriggerStay(Collider other)
    {
        RaycastHit hit;

        if (other.attachedRigidbody)
        {
            Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponentInParent<FloorTrigger>())
                {
                    Text.SetActive(true);
                }
            }
        }
    }
}
