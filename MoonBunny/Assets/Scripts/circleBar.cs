using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circleBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image LoadingBar;
    public Sprite greenBar;
    public Sprite yellowBar;
    public Sprite redBar;
    public float currentValue;
    public float speed;
    public int num = 0;
    public GameObject[] life = new GameObject[3];
    public Sprite emptyLife;
    public GameObject bgimage;
    public GameObject SCORE;
    public GameObject nowscore;
    public GameObject nowcarrot;
    public GameObject totalcarrot;
    public GameObject restartb;
    public GameObject quitb;
    public GameObject carrot;
    public GameObject guestTimer;
    public GameObject sauceCh;
    public GameObject timer;

    public GameObject scoreC;
    public AudioSource[] audioSource = new AudioSource[3]; //패시브, 종료1, 종료2

    private int level = 0;
    private float ro = 180;
    private float[] levelValue = { 110, 110, 110, 110, 100, 100, 100, 100, 90, 90, 90, 90, 80, 80, 80 };

    void Start()
    {
        audioSource[0].Play();
    }

    void TimerSound()
    {
        audioSource[0].Play();
    }

    // Update is called once per frame
    void Update()
    {

        GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();

        float i;
        level = (ScoreManager.score / 100) + 1;
        if (level - 1 >= levelValue.Length)
            i = 80;
        else i = levelValue[level - 1];


        if (currentValue < i + 2)
        {
            currentValue += speed * Time.deltaTime;

            if (currentValue >=0 && currentValue <= 30)
            {
                GameObject.Find("BackBar").GetComponent<Image>().sprite = greenBar; //green
            }

            if(currentValue > 30 && currentValue <= 60)
            {
                GameObject.Find("BackBar").GetComponent<Image>().sprite = yellowBar;
                //GameObject.Find("BackBar").GetComponent<Image>().color = new Color(255 / 255, 255 / 255, 90 / 255); //yellow
            }
            if(currentValue >60 && currentValue < 100)
            {
                GameObject.Find("BackBar").GetComponent<Image>().sprite = redBar;
                //GameObject.Find("BackBar").GetComponent<Image>().color = new Color(255 / 255, 0, 0); //red
            }

        }

        //시간오버시
        else if (!GameManager.success)
        {
            int rand = Random.Range(1, 3);
            if (rand == 1)
            {
                audioSource[1].Play();
                Invoke("TimerSound", 1f);
            }
            else if (rand == 2)
            {
                audioSource[2].Play();
                Invoke("TimerSound", 1f);
            }
            gm.num = 0;
            gm.snum = 0;
            gm.ChangeGuest();
            Debug.Log("num : " + num);
            life[num].GetComponent<SpriteRenderer>().sprite = emptyLife;
            num++;
            //this.gameObject.SetActive(false);
            GameManager.success = true;
        }

        if (num == 3)
        {
            bgimage.GetComponent<AudioSource>().Play();
            guestTimer.SetActive(false);
            bgimage.SetActive(true);
            SCORE.SetActive(true);
            nowscore.SetActive(true);
            nowcarrot.SetActive(true);
            totalcarrot.SetActive(true);
            restartb.SetActive(true);
            quitb.SetActive(true);
            timer.GetComponent<Timer>().enabled = false;
            //Time.timeScale = 0.0f;
            gm.enabled = false;

            sauceCh.GetComponent<SauceChange>().enabled = false;
            scoreC.GetComponent<ScoreCount>().gameover = true;
            

            //Destroy(guestTimer);

            //Invoke("gameOver", 2.0f);
        }

        LoadingBar.fillAmount = currentValue / i;
        //audioSource[0].Play();

        //carrot.transform.localEulerAngles = new Vector3(0, 0, ro);
    }


    public void GuestOn()
    {
        if (num == 3)
        {
            GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();

            guestTimer.SetActive(false);
            bgimage.SetActive(true);
            SCORE.SetActive(true);
            nowscore.SetActive(true);
            nowcarrot.SetActive(true);
            totalcarrot.SetActive(true);
            restartb.SetActive(true);
            quitb.SetActive(true);
            timer.GetComponent<Timer>().enabled = false;
            //Time.timeScale = 0.0f;
            gm.enabled = false;

            sauceCh.GetComponent<SauceChange>().enabled = false;
            scoreC.GetComponent<ScoreCount>().gameover = true;







            Invoke("gameOver", 2.0f);
        }
        //Debug.Log("timer on");
    }


    void gameOver()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
