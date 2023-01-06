using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionVibe : MonoBehaviour
{
    private Color grey = new Color(147/255f, 147/255f, 147/255f);
    public GameObject ON;
    public GameObject OFF;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("vibe") == 1)
        {
            ON.GetComponent<Image>().color = grey;
            OFF.GetComponent<Image>().color = Color.white;
        }

        else
        {
            ON.GetComponent<Image>().color = Color.white;
            OFF.GetComponent<Image>().color = grey;
        }
    }

    // Update is called once per frame
    public void VibeOff()
    {
        PlayerPrefs.SetInt("vibe", 0);
        ON.GetComponent<Image>().color = Color.white;
        OFF.GetComponent<Image>().color = grey;
    }

    public void VibeOn()
    {
        PlayerPrefs.SetInt("vibe", 1);
        ON.GetComponent<Image>().color = grey;
        OFF.GetComponent<Image>().color = Color.white;
        Vibration.Vibrate((long) 120);
    }

    public void OK()
    {
        if (PlayerPrefs.GetInt("vibe") == 1) Vibration.Vibrate((long)50);
    }
}
