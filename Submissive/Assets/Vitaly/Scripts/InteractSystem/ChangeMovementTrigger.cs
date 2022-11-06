using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMovementTrigger : MonoBehaviour
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    private bool _isEnter = false;

    public bool Interact(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isEnter && other.TryGetComponent<PlayerInvertedMovement>(out PlayerInvertedMovement invertedMovement))
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
            _isEnter = true;
        }
    }
}
