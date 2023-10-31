using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public GameObject Button_SoundON;
    public GameObject Button_SoundOff;
    public AudioSource BGMSounds;

    void Start()
    {
        BGMSounds.Play();
    }
    public void OnSoundButtonClicked()
    {
        Button_SoundON.SetActive(false);
        BGMSounds.Pause();
        Button_SoundOff.SetActive(true);
    }   
    public void OffSoundButtonClicked()
    {
        Button_SoundOff.SetActive(false);
        BGMSounds.Play();
        Button_SoundON.SetActive(true);

    }
}
