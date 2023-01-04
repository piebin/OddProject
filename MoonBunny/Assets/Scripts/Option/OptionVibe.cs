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
        PlayerPrefs.SetFloat("vibe", 0);
    }

    public void VibeOn()
    {
        PlayerPrefs.SetFloat("vibe", 1);
        Vibration.Vibrate((long)50);
    }
}
