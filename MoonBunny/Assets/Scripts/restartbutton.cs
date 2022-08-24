using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartbutton : MonoBehaviour
{
    public GameObject loadingDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void OnclickQuit()
    {
        SceneManager.LoadScene("Title");
    }
}
