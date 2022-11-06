using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Walker : MonoBehaviour
{

    public Transform LeftTarget;
    public Transform RightTarget;

    public float Speed;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    public Transform RayStart;

    private void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;

        //transform.position = new Vector3 (0f, 0f, LeftTarget.position.z);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (transform.position.z <= RightTarget.position.z)
        {
            gameObject.SetActive(false);
            return;
        }

        transform.position -= new Vector3(0f, 0f, Time.deltaTime * Speed);

        RaycastHit hit;
        if (Physics.Raycast(RayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }
}
