using System;
using UnityEngine;

public class Radio : MonoBehaviour, IInteractable
{
    public GameObject Door;

    [SerializeField] private AudioSource[] _audioSources;
    // Сюда вставьте нужную аудиодорожку радио
    [SerializeField] private AudioSource _trueRadioAudioSource;
    // Подпишите на это событие метод открывания двери
    // Пример:
    // |Объект крипта Radio|.CheckWasTrue += |Написанный в вашем классе метод открывания двери|
    // _radio.CheckWasTrue += OpenDoor;
    public event Action CheckWasTrue;
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
            CheckRadioTrack(_trueRadioAudioSource);
        }
        else
        {
            OffOrdinalAudioClip(_ordinalValueClip - 1);
            _ordinalValueClip = 0;
            PlayOrdinalAudioClip(_ordinalValueClip);
            CheckRadioTrack(_trueRadioAudioSource);
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

    // Проверка нужной аудиодорожки
    public bool CheckRadioTrack(AudioSource sourceTrack)
    {
        if (sourceTrack.isPlaying)
        {
            Debug.Log("return true");
            Door.SetActive(false);
            CheckWasTrue?.Invoke();
            return true;
        }
        else
        {
            Debug.Log("return false");
            return false;
        }
    }
}