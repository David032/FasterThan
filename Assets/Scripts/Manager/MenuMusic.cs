using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string MusicMenu;
    FMOD.Studio.EventInstance MusicEvent;
    FMOD.Studio.ParameterInstance MusicParameter;
    private float MusicValue;


    void Start()
    {
        MusicEvent = FMODUnity.RuntimeManager.CreateInstance(MusicMenu);
        MusicEvent.getParameter("Music", out MusicParameter);
    }

    void Update()
    {
        MusicParameter.setValue(MusicValue);
      
        if (SceneManager.GetActiveScene().name == ("GameLevel"))
        {
            MusicValue = 0.25f;
        }

        else

        {
            MusicValue = 0.15f;
        }

    }

}
