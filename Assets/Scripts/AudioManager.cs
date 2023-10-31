using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audMixer;
    [SerializeField] private Slider musicSlider;


    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audMixer.SetFloat("music", Mathf.Log10(volume)*20);
    }
}
