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
        bgm.value = 0.5f;
        sfx.value = 0.5f;

        mixer.SetFloat("bgmv", Mathf.Log10(bgm.value) * 20);
        mixer.SetFloat("sfxv", Mathf.Log10(sfx.value) * 20);
    }

    public void setBGM(float sliderVal)
    {
        mixer.SetFloat("bgmv", Mathf.Log10(sliderVal) * 20);
    }

    public void setSFX(float sliderVal)
    {
        mixer.SetFloat("sfxv", Mathf.Log10(sliderVal) * 20);
    }

}
