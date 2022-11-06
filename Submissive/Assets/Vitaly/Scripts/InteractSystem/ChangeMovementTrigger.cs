using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMovementTrigger : MonoBehaviour
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        //bool afk = other.TryGetComponent<Rigidbody>(out Rigidbody inv);
        //Debug.Log("TryGetComponent = " + afk + " " + other.name);
        if (other.TryGetComponent<PlayerInvertedMovement>(out PlayerInvertedMovement invertedMovement))
        {
            if (other.TryGetComponent<PlayerMovement>(out PlayerMovement normalMovement) && normalMovement.enabled == true)
            {
                normalMovement.enabled = false;
                invertedMovement.enabled = true;
            }
            else if (normalMovement.enabled == false)
            {
                normalMovement.enabled = true;
                invertedMovement.enabled = false;
            }
        }
    }
}
