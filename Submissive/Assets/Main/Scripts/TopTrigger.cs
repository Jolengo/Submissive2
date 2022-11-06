using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTrigger : MonoBehaviour
{
    public GameObject Door;
    public Camera PlayerCamera;

    void Update()
    {
        RaycastHit hit;

        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponentInParent<TopTrigger>())
            {
                Door.SetActive(false);
            }
        }
    }
}
