using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionVibe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void VibeOff()
    {
        PlayerPrefs.SetInt("vibe", 0);
    }

    public void VibeOn()
    {
        PlayerPrefs.SetInt("vibe", 1);
        Vibration.Vibrate((long) 120);
    }

    public void OK()
    {
        if (PlayerPrefs.GetInt("vibe") == 1) Vibration.Vibrate((long)50);
    }
}
