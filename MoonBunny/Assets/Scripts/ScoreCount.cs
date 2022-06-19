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
        totalscore = LastScoreInt+ScoreManager.score;

        scoreNum.text = ScoreManager.score.ToString();
        nowscore.text = ScoreManager.score.ToString();
        newcarrot.text = "+"+ScoreManager.score.ToString();
        totalC.text = totalscore.ToString();
        scoreUD();

    }

    void scoreUD()
    {
        StreamWriter Scorewriter;
        Scorewriter = File.CreateText(scoreTh);
        Scorewriter.WriteLine(totalC.text);
        Scorewriter.Close();
    }


}
