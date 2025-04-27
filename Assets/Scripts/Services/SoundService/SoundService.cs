using System.Linq;
using UnityEngine;

public class SoundService : MonoBehaviour, IService
{
    private AudioSource[] _audioSources;

    private void Start()
    {
        _audioSources = GetComponentsInChildren<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        if(clip == null)
        {
            return;
        }

        var freeAudioSource = _audioSources.FirstOrDefault(element => !element.isPlaying);

        if (freeAudioSource == null)
        {
            return;
        }

        freeAudioSource.loop = false;
        freeAudioSource.clip = clip;
        freeAudioSource.Play();
    }

    public void SetVolume(float volume)
    {
        foreach (var source in _audioSources)
        {
            source.volume = volume;
        }
    }
}
