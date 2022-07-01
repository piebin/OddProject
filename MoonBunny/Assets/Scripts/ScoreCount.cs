using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreCount : MonoBehaviour

{
    Text scoreNum;
    public Text nowscore;
    public Text newcarrot;
    public Text totalC;
    int LastScoreInt = 0;
    int totalscore = 0;

    string scoreTh = "Assets/TextFiles/score";

    // Start is called before the first frame update
    void Start()
    {
        scoreNum = GetComponent<Text>();

        FileStream LastScore = new FileStream(scoreTh, FileMode.Open);
        StreamReader LastScoreReader = new StreamReader(LastScore);
        LastScoreInt = int.Parse(LastScoreReader.ReadLine());
        LastScoreReader.Close();

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










    }



    IEnumerator count(float target, float current, Text score)
    {
        float duration = 1.3f;
        float offset = (target - current) / duration;

        while(current<target)
        {
            current += offset * Time.deltaTime;
            score.text = ((int)current).ToString();
            yield return null;
        }

        current = target;
        score.text = ((int)current).ToString();
    }


    IEnumerator Fade()
    {
        for(float f = 1f; f>=0; f-=0.1f)
        {
            Color c = nowscore.GetComponent<Renderer>().material.color;
            c.a = f;
            nowscore.GetComponent<Renderer>().material.color = c;
            yield return null;
        }
    }





    void scoreUD()
    {
        StreamWriter Scorewriter;
        Scorewriter = File.CreateText(scoreTh);
        Scorewriter.WriteLine(totalC.text);
        Scorewriter.Close();
    }


}
