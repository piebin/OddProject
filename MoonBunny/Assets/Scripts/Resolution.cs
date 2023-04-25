using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(1080, 2400, false);
        //Screen.SetResolution(Screen.width, (Screen.width * 20) / 9, false);
        Screen.SetResolution(Screen.width, Screen.height, false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}