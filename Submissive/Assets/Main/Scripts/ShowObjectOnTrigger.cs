using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectOnTrigger : MonoBehaviour
{
    public GameObject Object;
    public Camera PlayerCamera;

    void Update()
    {
        RaycastHit hit;

        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Object.SetActive(true);
            }
        }
    }
}
