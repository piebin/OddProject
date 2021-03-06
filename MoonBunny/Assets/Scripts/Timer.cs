using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Animator timerAnim;

    public GameObject bgimage;
    public GameObject SCORE;
    public GameObject nowscore;
    public GameObject nowcarrot;
    public GameObject totalcarrot;
    public GameObject restartb;
    public GameObject quitb;
    public GameObject guesttimer;
    private int num = 0;
    public GameObject sauceCh;
    public GameObject scoreC;


    // Start is called before the first frame update
    void Start()
    {

        timerAnim = GetComponent<Animator>();
        //timeOver = GameObject.Find("GameOver");

        //bgimage = GameObject.Find("bgimage");
        bgimage.SetActive(false);

        //SCORE = GameObject.Find("SCORE");
        SCORE.SetActive(false);

       // nowscore = GameObject.Find("nowscore");
        nowscore.SetActive(false);

        //nowcarrot = GameObject.Find("nowcarrot");
        nowcarrot.SetActive(false);

        //totalcarrot = GameObject.Find("totalcarrot");
        totalcarrot.SetActive(false);

        //restartb = GameObject.Find("restartb");
        restartb.SetActive(false);

        //quitb = GameObject.Find("quit");
        quitb.SetActive(false);


        //timeOver.SetActive(false);
    }

    void gameOver()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();

        if (timerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
            num++;
        }

        if(num == 1)
        {
            Debug.Log("Game Over");

            guesttimer.SetActive(false);
            bgimage.SetActive(true);
            SCORE.SetActive(true);
            nowscore.SetActive(true);
            nowcarrot.SetActive(true);
            totalcarrot.SetActive(true);
            restartb.SetActive(true);
            quitb.SetActive(true);
            gm.enabled = false;
            sauceCh.GetComponent<SauceChange>().enabled = false;
            scoreC.GetComponent<ScoreCount>().gameover = true;






            //Invoke("gameOver", 2.0f);
        }
    }
}
