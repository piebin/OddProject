using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private GameObject BackgroundMusic;
    private AudioSource backmusic;

    void Awake()
    {
        BackgroundMusic = GameObject.Find("BGM");
        backmusic = BackgroundMusic.GetComponent<AudioSource>();
        if (backmusic.isPlaying) return;
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(BackgroundMusic);
        }
    }
}