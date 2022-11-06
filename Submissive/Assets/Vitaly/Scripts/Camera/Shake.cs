using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Vector3 _startPosition;
    public bool _start = false;
    public AnimationCurve curve;
    public float duration = 1f;

    private void Update()
    {
        if (_start)
        {
            _start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            float xRotation = startPosition.x + UnityEngine.Random.Range(transform.rotation.x - 3f, transform.rotation.y + 3f) * strength;
            transform.rotation = Quaternion.Euler(xRotation, transform.rotation.y, 0);
            yield return null;
        }
        //transform.position = startPosition;
    }
}
