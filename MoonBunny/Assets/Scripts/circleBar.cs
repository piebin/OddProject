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

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();

        if (currentValue < 100)
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


        //시간오버시
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
            Invoke("gameOver", 2.0f);
        }

        LoadingBar.fillAmount = currentValue / 100;
    }


    public void GuestOn()
    {
        if (num == 3)
        {
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
