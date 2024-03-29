using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenButton : MonoBehaviour
{
    public GameObject gm, timer, circle, level, life, open, score, lvTimer;
    public GameObject loadingUp, loadingDown;
    public GameObject BGM1, BGM2;
    public GameObject openAnim1;
    private bool openChk = false;
    // Start is called before the first frame update
    void Start()
    {
        openAnim1.GetComponent<Animator>().enabled = false;
        openChk = false;
        GameManager.gamePlay = false;
        GameManager.gameStart = false;
        //open.GetComponent<Animator>().enabled = false;

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
        gm.GetComponent<GameManager>().backGround_desk.GetComponent<SpriteRenderer>().sprite = gm.GetComponent<GameManager>().BgDesksprites[PlayerPrefs.GetInt("ing_key")];

        Color color;
        ColorUtility.TryParseHtmlString(gm.GetComponent<GameManager>().scoreColor[PlayerPrefs.GetInt("ing_key")], out color);
        gm.GetComponent<GameManager>().score.GetComponent<Text>().color = color;
    }

    public void quitLoading()
    {
        BGM1.SetActive(true);
        BGM1.GetComponent<AudioSource>().Play();
        loadingUp.SetActive(false);
        //open.GetComponent<Animation>().Play();

        open.SetActive(true);

        open.GetComponent<Animator>().SetTrigger("open");
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
                    GameManager.gamePlay = false;
                    lvTimer.GetComponent<Animator>().speed = 0.0f;
                    lvTimer.GetComponent<Animator>().enabled = false;
                    Time.timeScale = 0.0f;
                    gm.GetComponent<GameManager>().titlePanel.SetActive(true);
                    if(PlayerPrefs.GetInt("vibe") == 1) Vibration.Vibrate((long)200);
                    gm.GetComponent<GameManager>().dark.SetActive(true);
                    gm.GetComponent<GameManager>().goBack.GetComponent<AudioSource>().Play();

                    float sound = Mathf.Log10(PlayerPrefs.GetFloat("bgm_sound") * 20)-30f;

                    gm.GetComponent<GameManager>().mixer.SetFloat("bgmv", sound);
                }
            }
        }

        if (loadingDown.activeSelf == true || loadingUp.activeSelf == true)
        {
            open.SetActive(false);

            gm.GetComponent<GameManager>().GuestBar.SetActive(false);
            //score.SetActive(false);
        }

        else if(!openChk)
        {
            open.SetActive(true);

            //open.GetComponent<Animator>().SetTrigger("open");
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
        openAnim1.GetComponent<Animator>().enabled = true;
        //open.GetComponent<Animator>().enabled = true;
        open.GetComponent<Animator>().SetTrigger("clicked");
        //score.SetActive(true);
    }


    // Update is called once per frame
}
