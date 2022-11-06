using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _musicMenuButton;

    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement normalMovement))
        {
            if (!_musicMenuButton.activeSelf)
            {
                _musicMenuButton.SetActive(true);
            }
        }
    }
}
