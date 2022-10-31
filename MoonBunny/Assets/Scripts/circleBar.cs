using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circleBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image LoadingBar;

    public Sprite red1;
    public Sprite red2;
    public Sprite red3;
    public Sprite red4;
    public Sprite red5;
    public Sprite red6;
    public Sprite red7;
    public Sprite red8;

    public float currentValue;
    public float speed;
    public float FA;
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

    int losingHeart = 0;



    void Start()
    {
        losingHeart = PlayerPrefs.GetInt("losing_heart");
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

            FA = currentValue / i;

            if (FA >=0 && FA <= 0.127)
            {
                GameObject.Find("Bar").GetComponent<Image>().sprite = red1;
            }

            if(FA > 0.127 && FA <= 0.255)
            {
                GameObject.Find("Bar").GetComponent<Image>().sprite = red2;
            }
            if(FA >0.255 && FA < 0.389)
            {
                GameObject.Find("Bar").GetComponent<Image>().sprite = red3;
            }
            if (FA > 0.389 && FA < 0.505)
            {
                GameObject.Find("Bar").GetComponent<Image>().sprite = red4;
            }
            if (FA > 0.505 && FA < 0.622)
            {
                GameObject.Find("Bar").GetComponent<Image>().sprite = red5;
            }
            if (FA > 0.622 && FA < 0.755)
            {
                GameObject.Find("Bar").GetComponent<Image>().sprite = red6;
            }
            if (FA > 0.755 && FA < 0.867)
            {
                GameObject.Find("Bar").GetComponent<Image>().sprite = red7;
            }
            if (FA > 0.867 && FA < 1)
            {
                GameObject.Find("Bar").GetComponent<Image>().sprite = red8;
            }

        }

        //시간오버시
        else if (!GameManager.success)
        {
            losingHeart++;

            int rand = Random.Range(1, 3);
            if (rand == 1)
            {
                audioSource[1].Play();
            }
            else if (rand == 2)
            {
                audioSource[2].Play();
            }
            //gm.num = 0;
            //gm.snum = 0;
            gm.ChangeGuest();
            Debug.Log("num : " + num);
            life[num].GetComponent<SpriteRenderer>().sprite = emptyLife;
            num++;
            //this.gameObject.SetActive(false);
            GameManager.success = true;
        }

        if (num == 3)
        {
            gm.enabled = false;
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

            sauceCh.GetComponent<SauceChange>().enabled = false;
            scoreC.GetComponent<ScoreCount>().gameover = true;

            //Destroy(guestTimer);
            //Invoke("gameOver", 2.0f);


            PlayerPrefs.SetInt("losing_heart", losingHeart);

            if(losingHeart == 20)//업적 2번 달성
            {
                if (PlayerPrefs.GetInt("achieve_key2") == 0)
                {
                    Debug.Log("achieve2 clear");
                    gm.clearTwo();
                    PlayerPrefs.SetInt("achieve_key1", 1);
                }

            }
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
            gm.enabled = false;
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
