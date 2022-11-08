using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public void OnClick1()
    {
        Vibration.Vibrate((long)600);
    }

    public void OnClick2()
    {
        Vibration.Vibrate((long)330);
    }

    public void OnClick3()
    {
        long[] pattern = new long[6];
        pattern[0] = 0;
        pattern[1] = 700;
        pattern[2] = 500;
        pattern[3] = 700;
        pattern[4] = 500;
        pattern[5] = 700;


        Vibration.Vibrate(pattern, -1);
    }

    public void OnClick4()
    {
        Vibration.Vibrate(400);
    }
}