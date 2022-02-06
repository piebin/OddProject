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
        }
        //시간오버시
        else 
        {
            gm.ChangeGuest();
            Debug.Log("time over");
            life[num].GetComponent<SpriteRenderer>().sprite = emptyLife;
            num++;
            this.gameObject.SetActive(false);
            
        }

        if (num == 3)
        {
            Debug.Log("Game Over");
            timeOver.SetActive(true);
            Invoke("gameOver", 2.0f);
        }

        LoadingBar.fillAmount = currentValue / i;
    }


    public void GuestOn()
    {
        if (num == 3)
        {
            Debug.Log("Game Over");
            timeOver.SetActive(true);
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
