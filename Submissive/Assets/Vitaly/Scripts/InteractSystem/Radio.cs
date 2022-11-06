using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource[] _audioSources;
    public int _ordinalValueClip;

    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    private void Start()
    {
        _ordinalValueClip = 0;

        //PlayOrdinalAudioClip(_ordinalValueClip);
    }

    public bool Interact(Interactor interactor)
    {
        OffOrdinalAudioClip(_ordinalValueClip);
        _ordinalValueClip += 1;
        if (_ordinalValueClip >= 0 && _ordinalValueClip <= _audioSources.Length - 1)
        {
            PlayOrdinalAudioClip(_ordinalValueClip);
        }
        else
        {
            OffOrdinalAudioClip(_ordinalValueClip - 1);
            _ordinalValueClip = 0;
            PlayOrdinalAudioClip(_ordinalValueClip);
        }
        Debug.Log("Turn music");
        return true;
    }

    private void PlayOrdinalAudioClip(int ordinalValueClip)
    {
        _audioSources[ordinalValueClip].Play();
    }

    private void OffOrdinalAudioClip(int ordinalValueClip)
    {
        _audioSources[ordinalValueClip].Stop();
    }
}
