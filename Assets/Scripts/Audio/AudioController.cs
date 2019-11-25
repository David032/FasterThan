using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip Walk; //Movement
    public AudioClip Sneak;
    public AudioClip Run;
    public AudioClip Jump;
    public AudioClip Land;

    public AudioClip Wood; //Surface 
    public AudioClip Metal;
    public AudioClip Stone;
    public AudioClip Grass;
    //public AudioClip Water;
    public AudioClip Sand;
    public AudioClip HollowWood;
    public AudioClip HollowMetal;
    public AudioClip HollowStone;
    public AudioClip Puddle;
    public AudioClip ShallowWater;
    public AudioClip DeepWater;


    public bool isPlaying = false;

    AudioSource player;
    
    //At the moment all Random pitch is set to (0.75-1.25f) 
    //we can change as we see fit when we have the audio :)

    private void Start()
    {
        player = GetComponent<AudioSource>();
    }

    public void Walk()
    {
        player.clip = Walk;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void Sneak()
    {
        player.clip = Sneak;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void Run()
    {
        player.clip = Run;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void Jump()
    {
        player.clip = Jump;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void Land()
    {
        player.clip = Land;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void StopAudio()
    {
        player.Stop();
    }

    public void Wood()
    {
        player.clip = Wood;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void Metal()
    {
        player.clip = Metal;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void Stone()
    {
        player.clip = Stone;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void Grass()
    {
        player.clip = Grass;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void Water()
    {
        player.clip = Water;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void Sand()
    {
        player.clip = Sand;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void HallowWood()
    {
        player.clip = HallowWood;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }

    public void HallowMetal()
    {
        player.clip = HallowMetal ;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }
    public void HallowStone()
    {
        player.clip = HallowStone;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }
    public void Puddle()
    {
        player.clip = Puddle;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }
    public void ShallowWater()
    {
        player.clip = ShallowWater;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }
    public void DeepWater()
    {
        player.clip = DeepWater;
        player.pitch = Random.Range(0.75f, 1.25f);
        player.Play();
    }
}
