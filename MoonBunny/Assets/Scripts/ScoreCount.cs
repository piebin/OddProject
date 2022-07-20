using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreCount : MonoBehaviour

{
    public Text scoreNum;
    public Text nowscore;
    public Text newcarrot;
    public Text totalC;
    int LastScoreInt = 0;
    int totalscore = 0;
    public bool gameover = false;
    public bool noclick = false;
    public GameObject bgimage;

    // Start is called before the first frame update
    void Start()
    {
        LastScoreInt = PlayerPrefs.GetInt("score_key");

    }

    // Update is called once per frame
    void Update()
    {
        totalscore = LastScoreInt+ScoreManager.score;//최종점수

        //ui텍스트 입력
        scoreNum.text = ScoreManager.score.ToString();

        nowscore.text = ScoreManager.score.ToString();//현재 획득 점수

        newcarrot.text = "+"+ScoreManager.score.ToString(); //현재 획득 점수

        totalC.text = totalscore.ToString();//최종점수

        scoreUD();//최종 점수 파일 저장


        if (Input.GetMouseButtonDown(0))
        {
            noclick = true;

            StopCoroutine(Fade());
            StopCoroutine(countnew((float)ScoreManager.score, 0f));
            StopCoroutine(counttotal((float)totalscore, 0f));

            nowscore.text = ScoreManager.score.ToString();//현재 획득 점수

            newcarrot.text = "+" + ScoreManager.score.ToString(); //현재 획득 점수

            totalC.text = totalscore.ToString();//최종점수

        }


        if (gameover)
        {
            GOver();
            gameover = false;
            PlayerPrefs.SetInt("game_over", 1);
        }

        if(totalscore==150000)
        {
            GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();

            if (PlayerPrefs.GetInt("achieve_key2")==0)
            {
                Debug.Log("achieve3 clear");
                gm.clearOne();
                PlayerPrefs.SetInt("achieve_key2", 1);
            }
        }
        //업적 3번 달성




    }


    public void GOver()
    {
        StartCoroutine(Fade());
        StartCoroutine(countnew((float)ScoreManager.score, 0f));
        StartCoroutine(counttotal((float)totalscore, 0f));
    }


    IEnumerator countnew(float target, float current)
    {

        float duration = 1.0f;
        float offset = (target - current) / duration;

        while (current < target)
        {
            current += offset * Time.deltaTime;
            nowscore.text = ((int)current).ToString();
            yield return null;
        }

        current = target;
        nowscore.text = ((int)current).ToString();

    }


    IEnumerator counttotal(float target, float current)
    {

        float duration = 1.3f;
        float offset = (target - current) / duration;

        while (current < target)
        {
            current += offset * Time.deltaTime;
            totalC.text = ((int)current).ToString();
            yield return null;
        }

        current = target;
        totalC.text = ((int)current).ToString();



    }


    IEnumerator Fade()
    {
        for(float f = 1f; f>=0; f-=0.001f)
        {
            Color c = newcarrot.GetComponent<Text>().color;
            c.a = f;
            newcarrot.GetComponent<Text>().color = c;
            yield return null;
        }

        Time.timeScale = 0;
    }






    void scoreUD()
    {

        PlayerPrefs.SetInt("score_key", totalscore);
    }


}
