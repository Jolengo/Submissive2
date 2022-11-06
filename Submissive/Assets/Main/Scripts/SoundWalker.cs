using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SoundWalker : MonoBehaviour
{
    public GameObject NextObject;

    public Transform LeftTarget;
    public Transform RightTarget;

    public float Speed;

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
        if (transform.localPosition.x <= RightTarget.localPosition.x)
        {
            if (NextObject)
                NextObject.SetActive(true);

            gameObject.SetActive(false);
            return;
        }

        transform.localPosition -= new Vector3(Time.deltaTime * Speed, 0f, 0f);

        RaycastHit hit;
        if (Physics.Raycast(RayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }
}
