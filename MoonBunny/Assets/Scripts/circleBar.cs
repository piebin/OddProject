using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circleBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image LoadingBar;
    public float currentValue;
    public float speed;
    public int num = 0;
    public GameObject[] life = new GameObject[3];
    public Sprite emptyLife;
    public GameObject timeOver;
    public GameObject bgimage;
    public GameObject SCORE;
    public GameObject nowscore;
    public GameObject nowcarrot;
    public GameObject totalcarrot;
    public GameObject restartb;
    public GameObject quitb;



    private int level = 0;
    private float[] levelValue = { 110, 110, 110, 110, 100, 100, 100, 100, 90, 90, 90, 90, 80, 80, 80 };

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float i;
        level = (ScoreManager.score / 100) + 1;
        if (level - 1 >= levelValue.Length)
            i = 80;
        else i = levelValue[level - 1];
        GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();

        if (currentValue < i)
        {
            currentValue += speed * Time.deltaTime;

            if (currentValue >=0 && currentValue <= 30)
            {
                GameObject.Find("BackBar").GetComponent<Image>().color = new Color(54 / 255, 255 / 255, 0); //green
            }

            if(currentValue > 30 && currentValue <= 60)
            {
                GameObject.Find("BackBar").GetComponent<Image>().color = new Color(255 / 255, 255 / 255, 90 / 255); //yellow
            }
            if(currentValue >60 && currentValue < 100)
            {
                GameObject.Find("BackBar").GetComponent<Image>().color = new Color(255 / 255, 0, 0); //red
            }

        }


        //�ð�������
        else 
        {
            gm.ChangeGuest();
            life[num].GetComponent<SpriteRenderer>().sprite = emptyLife;
            num++;
            this.gameObject.SetActive(false);
            
        }

        if (num == 3)
        {
            timeOver.SetActive(true);
            bgimage.SetActive(true);
            SCORE.SetActive(true);
            nowscore.SetActive(true);
            nowcarrot.SetActive(true);
            totalcarrot.SetActive(true);
            restartb.SetActive(true);
            quitb.SetActive(true);

            Invoke("gameOver", 2.0f);
        }

        LoadingBar.fillAmount = currentValue / i;
    }


    public void GuestOn()
    {
        if (num == 3)
        {
            timeOver.SetActive(true);
            bgimage.SetActive(true);
            SCORE.SetActive(true);
            nowscore.SetActive(true);
            nowcarrot.SetActive(true);
            totalcarrot.SetActive(true);
            restartb.SetActive(true);
            quitb.SetActive(true);

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
