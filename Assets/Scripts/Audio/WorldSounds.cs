using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSounds : MonoBehaviour
{
    public AudioSource audio_source;

    public AudioClip Wind; //nature background
    public AudioClip WhistleOfWind;
    public AudioClip Thunder;
    //public AudioClip Fire;
    public AudioClip RushOfWater;
    public AudioClip Drip;
    public AudioClip RiverFlow;
    public AudioClip TorchFire;
    public AudioClip OpenFire;
    public AudioClip Blaze;

    public AudioClip BirdHoot; //Birds
    public AudioClip BirdTweet;
    public AudioClip BirdSing;

    public AudioClip BearHuffing; //Bears
    public AudioClip BearRoar;
    public AudioClip BearBreathing;

    public AudioClip FoxBark; //Foxes
    public AudioClip FoxHowl;
    public AudioClip FoxCall;

    public AudioClip WolfBark; //Wolf
    public AudioClip WolfHowl;
    public AudioClip WolfGrowl;
    public AudioClip WolfWhimper;

    public AudioClip RatSqueak; //Rat
    public AudioClip RatHissing;
    public AudioClip RatChattering;
    public AudioClip RatGrindTeeth;

    public AudioClip Background_Birds; //background animals
    public AudioClip Background_Foxes;
    public AudioClip Background_Bears;
    public AudioClip Background_Wolves;
    public AudioClip Background_Rats;

    //At the moment all Random pitch is set to (0.75-1.25f) 
    //we can change as we see fit when we have the audio :)


    public void SetNewState(bool music_state)
    {
        audio_source.mute = music_state;
    }

    public void PlayWind()
    {
        audio_source.clip = Wind;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayWhistleOfWind()
    {
        audio_source.clip = WhistleOfWind;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayThunder()
    {
        audio_source.clip = Thunder;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayDrip()
    {
        audio_source.clip = Drip;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayRushOfWater()
    {
        audio_source.clip = RushOfWater;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayRiverFlow()
    {
        audio_source.clip = RiverFlow;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayTorchFire()
    {
        audio_source.clip = TorchFire;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayBlaze()
    {
        audio_source.clip = Blaze;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayOpenFire()
    {
        audio_source.clip = OpenFire;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayBirdHoot()
    {
        audio_source.clip = BirdHoot;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayBirdSing()
    {
        audio_source.clip = BirdSing;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayBirdTweet()
    {
        audio_source.clip = BirdTweet;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayBearHuffing()
    {
        audio_source.clip = BearHuffing;
        audio_source.Play();
    }

    public void PlayBearBreathing()
    {
        audio_source.clip = BearBreathing;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayBearRoar()
    {
        audio_source.clip = BearRoar;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayFoxBark()
    {
        audio_source.clip = FoxBark;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayFoxHowl()
    {
        audio_source.clip = FoxHowl;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayFoxCall()
    {
        audio_source.clip = FoxCall;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }
    public void PlayWolfBark()
    {
        audio_source.clip = WolfBark;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }
    public void PlayWolfHowl()
    {
        audio_source.clip = WolfHowl;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayWolfGrowl()
    {
        audio_source.clip = WolfGrowl;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayWolfWhimper()
    {
        audio_source.clip = WolfWhimper;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayRatChattering()
    {
        audio_source.clip = RatChattering;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayRatHissing()
    {
        audio_source.clip = RatHissing;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayRatSqueak()
    {
        audio_source.clip = RatSqueak;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayRatGrind()
    {
        audio_source.clip = RatGrind;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayBackgroundBirds()
    {
        audio_source.clip = Background_Birds;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayBackgroundFoxes()
    {
        audio_source.clip = Background_Foxes;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayBackgroundBears()
    {
        audio_source.clip = Background_Bears;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayBackgroundWolves()
    {
        audio_source.clip = Background_Wolves;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }

    public void PlayBackgroundRats()
    {
        audio_source.clip = Background_Rats;
        audio_source.pitch = Random.Range(0.75f, 1.25f);
        audio_source.Play();
    }
}