using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumMG : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider bgm;
    public Slider sfx;


    public void Start()
    {
        bgm.value = PlayerPrefs.GetFloat("bgm_sound");
        sfx.value = PlayerPrefs.GetFloat("sfx_sound");

        mixer.SetFloat("bgmv", Mathf.Log10(bgm.value) * 20);
        mixer.SetFloat("sfxv", Mathf.Log10(sfx.value) * 20);

    }

    public void setBGM(float sliderVal)
    {
        mixer.SetFloat("bgmv", Mathf.Log10(sliderVal) * 20);
        PlayerPrefs.SetFloat("bgm_sound", sliderVal);
    }

    public void setSFX(float sliderVal)
    {
        mixer.SetFloat("sfxv", Mathf.Log10(sliderVal) * 20);
        PlayerPrefs.SetFloat("sfx_sound", sliderVal);
    }

}
