using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    public AudioClip MenuMusic;
    public AudioClip GameMusic;
    public AudioClip Button;
    public AudioClip WinScreen;
    public AudioClip LossScreen;
    public AudioClip Voices;
    public AudioClip Whistling;

    AudioSource audio_source;

    public void PlayMenuMusic()
    {
        audio_source.clip = MenuMusic;
        audio_source.Play();
    }

    public void PlayGameMusic()
    {
        audio_source.clip = GameMusic;
        audio_source.Play();
    }


    public void PlayButton()
    {
        audio_source.clip = Button;
        audio_source.Play();
    }

    public void WinScreen()
    {
        audio_source.clip = WinScreen;
        audio_source.Play();
    }

    public void PlayLossScreen()
    {
        audio_source.clip = LossScreen;
        audio_source.Play();
    }

    //At the moment all Random pitch is set to (0.75-1.25f) 
    //we can change as we see fit when we have the audio :)
    public void PlayVoices()
    {
        audio_source.clip = Voices;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayWhistling()
    {
        audio_source.clip = Whistling;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }
}
