using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    public GameObject gm, timer, circle, level, life, open, score, lvTimer;
    public GameObject loadingUp, loadingDown;
    public GameObject BGM1, BGM2;
    private bool openChk = false;
    // Start is called before the first frame update
    void Start()
    {
        loadingUp.SetActive(true);
        Invoke("quitLoading", 1.0f);
        gm.SetActive(false);
        timer.SetActive(false);
        circle.SetActive(false);
        level.SetActive(false);
        life.SetActive(false);
        open.SetActive(false);
        BGM1.SetActive(false);
        BGM2.SetActive(false);
        //score.SetActive(false);

        gm.GetComponent<GameManager>().backGround.GetComponent<SpriteRenderer>().sprite = gm.GetComponent<GameManager>().BgSprites[PlayerPrefs.GetInt("ing_key")];
    }

    public void quitLoading()
    {
        BGM1.SetActive(true);
        BGM1.GetComponent<AudioSource>().Play();
        loadingUp.SetActive(false);
        open.SetActive(true);
        //score.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gm.GetComponent<GameManager>().goBack)
                {
                    lvTimer.GetComponent<Animator>().speed = 0.0f;
                    lvTimer.GetComponent<Animator>().enabled = false;
                    Time.timeScale = 0.0f;
                    gm.GetComponent<GameManager>().titlePanel.SetActive(true);
                    Vibration.Vibrate((long)200);
                    gm.GetComponent<GameManager>().dark.SetActive(true);
                    gm.GetComponent<GameManager>().goBack.GetComponent<AudioSource>().Play();
                }
            }
        }

        if (loadingDown.activeSelf == true || loadingUp.activeSelf == true)
        {
            open.SetActive(false);
            //score.SetActive(false);
        }

        else if(!openChk)
        {
            open.SetActive(true);
            //score.SetActive(true);
        }

        //else
        //{
        //    open.SetActive(false);
        //    //score.SetActive(false);
        //}
    }

    public void openBtn()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gm.SetActive(true);
        timer.SetActive(true);
        circle.SetActive(true);
        level.SetActive(true);
        life.SetActive(true);
        //open.SetActive(false);
        openChk = true;
        BGM1.GetComponent<AudioSource>().Stop();
        BGM1.SetActive(false);
        BGM2.SetActive(true);
        BGM2.GetComponent<AudioSource>().Play();
        //score.SetActive(true);
    }

    // Update is called once per frame
}
