using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour

{
    Text scoreNum;
    // Start is called before the first frame update
    void Start()
    {
        scoreNum = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreNum.text = ScoreManager.score.ToString();
    }
}
