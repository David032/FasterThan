using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManagment : MonoBehaviour
{

    FMOD.Studio.Bus MasterBus;

    float MasterVolume = 0.5f;
    float MusicVolume = 1;
    float EntityVolume = 1;
    float AmbianceVolume = 1;

    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider EntitySlider;
    public Slider AmbianceSlider;

    private void Awake()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("bus:/Master");

        MasterSlider.value = MasterVolume;
        MusicSlider.value = MusicVolume;
        EntitySlider.value = EntityVolume;
        AmbianceSlider.value = AmbianceVolume;

        MasterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    void SetMasterVolume(float value)
    {
        MasterBus.setVolume(value);
    }
}
