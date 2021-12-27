using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class incLevel : MonoBehaviour
{
    private int level;
    private Text showLevel;
    // Start is called before the first frame update
    void Start()
    {
        showLevel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        level = (ScoreManager.score / 30) + 1;
        showLevel.text = "Lv. " + level;
    }
}
