using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManagment : MonoBehaviour
{
    float MasterVolume = 1;
    float MusicVolume = 1;
    float EntityVolume = 1;
    float AmbianceVolume = 1;

    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider EntitySlider;
    public Slider AmbianceSlider;

    private void Awake()
    {
        MasterSlider.value = MasterVolume;
        MusicSlider.value = MusicVolume;
        EntitySlider.value = EntityVolume;
        AmbianceSlider.value = AmbianceVolume;
    }

    private void Update()
    {
        setValues();
        print(MasterVolume + MusicVolume + EntityVolume + AmbianceVolume);
        //Function to update the scaling of all audio should go here
    }

    void setValues() 
    {
        MasterVolume = MasterSlider.value;
        MusicVolume = MusicSlider.value;
        EntityVolume = EntitySlider.value;
        AmbianceVolume = AmbianceSlider.value;
    }
}
