using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    public GameObject gm, timer, circle, level, life, open;
    // Start is called before the first frame update
    void Start()
    {
        gm.SetActive(false);
        timer.SetActive(false);
        circle.SetActive(false);
        level.SetActive(false);
        life.SetActive(false);
    }

    public void openBtn()
    {
        gm.SetActive(true);
        timer.SetActive(true);
        circle.SetActive(true);
        level.SetActive(true);
        life.SetActive(true);
        open.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
