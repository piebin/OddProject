using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void titleBtn()
    {
        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
