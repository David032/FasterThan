using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSounds : MonoBehaviour
{

    AudioSource monster;

    public AudioClip LostSight;
    public AudioClip MonsterHowl;
    public AudioClip MonsterInSight;
    public AudioClip MonsterContact;
    public AudioClip MonsterPlayerDeath;
    public AudioClip MonsterMovement;

    //At the moment all Random pitch is set to (0.75-1.25f) 
    //we can change as we see fit when we have the audio :)

    public void LostSight()
    {
        monster.clip = LostSight;
        monster.pitch = Random.Range(0.75f, 1.25f);
        monster.Play();
    }

    public void MonsterHowl()
    {
        monster.clip = MonsterHowl;
        monster.pitch = Random.Range(0.75f, 1.25f);
        monster.Play();
    }

    public void MonsterInSight()
    {
        monster.clip = MonsterInSight;
        monster.pitch = Random.Range(0.75f, 1.25f);
        monster.Play();
    }

    public void MonsterContact()
    {
        monster.clip = MonsterContact;
        monster.pitch = Random.Range(0.75f, 1.25f);
        monster.Play();
    }

    public void MonsterPlayerDeath()
    {
        monster.clip = MonsterPlayerDeath;
        monster.pitch = Random.Range(0.75f, 1.25f);
        monster.Play();
    }

    public void MonsterMovement()
    {
        monster.clip = MonsterMovement;
        monster.pitch = Random.Range(0.75f, 1.25f);
        monster.Play();
    }
}
