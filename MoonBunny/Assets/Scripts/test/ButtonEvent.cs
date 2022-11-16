using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public void OnClick1()
    {
        Vibration.Vibrate((long)10);
    }

    public void OnClick2()
    {
        Vibration.Vibrate((long)170);
    }

    public void OnClick3()
    {
        Vibration.Vibrate((long)600);
    }

    public void OnClick4()
    {
        Vibration.Vibrate((long)1200);
    }
}