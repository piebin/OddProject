using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartbutton : MonoBehaviour
{
    public GameObject loadingDown;
    public GameObject BGM2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static IEnumerator FadeOut(GameObject source, float FadeTime)
    {
        AudioSource audioSource = source.GetComponent<AudioSource>();
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
    }

    public void OnClickRestart()
    {
        loadingDown.SetActive(true);
        Invoke("LoadGame", 1.5f);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnclickQuit()
    {
        PlayerPrefs.SetInt("go_title", 1);
        if (PlayerPrefs.GetInt("vibe") == 1) Vibration.Vibrate((long)20);
        loadingDown.SetActive(true);
        StartCoroutine(FadeOut(BGM2, 1.5f));
        Invoke("LoadTitle", 1.8f);
    }
}
