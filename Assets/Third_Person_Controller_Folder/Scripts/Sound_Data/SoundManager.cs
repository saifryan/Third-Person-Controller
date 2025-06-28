using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [Header("----- AudioSource Data -----")]
    public AudioSource audiosource;
    public int TotalAudioSourceSpawn = 100;
    List<AudioSource> TempAudioSourceStore = new List<AudioSource>();
    int AudioSourceCounter = 0;
    [Header("----- Audio Clip Data -----")]
    public AudioClip DoorOpen;
    public AudioClip FeedBackShow;
    public AudioClip DoorClose;
    public AudioClip LeverPull;
    public AudioClip LeverDoorOpen;
    public AudioClip FootStep;
    public AudioClip JumpStart;
    public AudioClip JumpLand;
    public AudioClip StonePush;
    public AudioClip CoinCollect;
    public AudioClip WinSound;
    public AudioClip LoseSound;
    public AudioClip ButtonClick;
    public AudioClip PopupOpen;
    public AudioClip PopupClose;


    private void Awake()
    {
        Instance = this;
        if (TempAudioSourceStore.Count <= 0)
            AudioSourceSpawnFunction();
    }


    void AudioSourceSpawnFunction()
    {
        for (int i = 0; i < TotalAudioSourceSpawn; i++)
        {
            TempAudioSourceStore.Add(Instantiate(audiosource, transform.position, transform.rotation, transform));
        }
    }



    AudioSource GetAudioSource()
    {
        AudioSource tempaudiosource = TempAudioSourceStore[AudioSourceCounter];
        AudioSourceCounter++;
        if (AudioSourceCounter >= TempAudioSourceStore.Count)
        {
            AudioSourceCounter = 0;
        }
        return tempaudiosource;
    }


    public void PlaySound(AudioClip audioclip)
    {
        if (audioclip != null)
        {
            AudioSource temosudiosource = GetAudioSource();
            temosudiosource.clip = audioclip;
            temosudiosource.loop = false;
            temosudiosource.Play();
        }
    }

    public AudioSource PlaySoundLoop(AudioClip audioclip)
    {
        AudioSource temosudiosource = null;
        if (audioclip != null)
        {
            temosudiosource = GetAudioSource();
            temosudiosource.clip = audioclip;
            temosudiosource.loop = true;
            temosudiosource.Play();
        }
        return temosudiosource;
    }
}
