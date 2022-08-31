using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    public GameObject gm, timer, circle, level, life, open, score, lvTimer;
    public GameObject loadingUp, loadingDown;
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
        score.SetActive(false);
    }

    public void quitLoading()
    {
        loadingUp.SetActive(false);
        open.SetActive(true);
        score.SetActive(true);
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
                    gm.GetComponent<GameManager>().titlePanel.SetActive(true);
                    gm.GetComponent<GameManager>().dark.SetActive(true);
                    gm.GetComponent<GameManager>().goBack.GetComponent<AudioSource>().Play();
                    gm.GetComponent<GameManager>().GuestBar.SetActive(false);
                    lvTimer.GetComponent<Animator>().speed = 0.0f;
                    lvTimer.GetComponent<Animator>().enabled = false;
                    Time.timeScale = 0.0f;
                }
            }
        }

        if (loadingDown.activeSelf == true || loadingUp.activeSelf == true)
        {
            open.SetActive(false);
            score.SetActive(false);
        }

        else if(!openChk)
        {
            open.SetActive(true);
            score.SetActive(true);
        }

        else
        {
            open.SetActive(false);
            score.SetActive(false);
        }
    }

    public void openBtn()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gm.SetActive(true);
        timer.SetActive(true);
        circle.SetActive(true);
        level.SetActive(true);
        life.SetActive(true);
        open.SetActive(false);
        openChk = true;
    }

    // Update is called once per frame

}
