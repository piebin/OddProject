using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TitleSound : MonoBehaviour
{
    public AudioMixer mixer;
    public float bgm_value;
    public float sfx_value;

    public void Start()
    {
        bgm_value = PlayerPrefs.GetFloat("bgm_sound");
        sfx_value = PlayerPrefs.GetFloat("sfx_sound");

        mixer.SetFloat("bgmv", Mathf.Log10(bgm_value) * 20);
        mixer.SetFloat("sfxv", Mathf.Log10(sfx_value) * 20);
    }
}
