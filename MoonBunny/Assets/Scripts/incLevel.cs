using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class incLevel : MonoBehaviour
{
    private int level, nowLevel = 1;
    private Text showLevel;
    private int[] lvTimerArray = { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4 };
    private Animator anim;
    public GameObject panel, lvTimer;
    // Start is called before the first frame update
    void Start()
    {
        anim = lvTimer.GetComponent<Animator>();
        panel.SetActive(false);
        showLevel = GetComponent<Text>();
    }

    void LevelUp()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        level = (ScoreManager.score / 100) + 1;
        showLevel.text = "Lv. " + level;
        if(level != nowLevel)
        {
            int i;
            panel.SetActive(true);
            Invoke("LevelUp", 1.5f);
            if (level - 1 >= lvTimerArray.Length)
                i = 4;
            else i = lvTimerArray[level - 1];
            Debug.Log("i : " + i);
            anim.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("LevelAnim\\level"+i, typeof(RuntimeAnimatorController)));
            nowLevel = level;
        }
    }
}
