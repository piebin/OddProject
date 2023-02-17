using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeBg : MonoBehaviour
{
    public Sprite[] bg = new Sprite[3]; //0:기본 1:한옥 2:카페
    public Sprite[] price = new Sprite[3]; //배경별 가격
    public Sprite[] stateBG = new Sprite[2]; //0:적용중 1:구매완료
    public Sprite[] setBG = new Sprite[2]; //0:적용 1:구매
    public GameObject oriState, oriSet, BackGround;
    public GameObject purchasePanel, right, left;
    public Text carrot;
    private int num = 0, myCarrot;
    private bool check = false;
    public static bool touchChk = false;
    private int[] priceBG = { 50000, 50000, 60000 };
    private int[] state = { 0, 2, 2 }; //0:적용중 1:구매완료 2:가격
    // Start is called before the first frame update
    void Start()
    {
        check = true;
        purchasePanel.SetActive(false);
        Int32.TryParse(carrot.text, out myCarrot);
    }

    public void rightBtn()
    {
        if (num == bg.Length - 1)
            num += 0;
        else
        {
            num++;
            check = true;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = bg[num];
    }

    public void leftBtn()
    {
        if (num == 0)
            num += 0;
        else
        {
            num--;
            check = true;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = bg[num];
    }

    public void setBtn()
    {
        if(state[num] == 0) { }

        else if(state[num] == 1) //적용
        {
            for(int i = 0; i < state.Length; i++)
            {
                if (state[i] == 0)
                    state[i] = 1;
            }
            state[num] = 0;
            check = true;
        }

        else if(state[num] == 2) //구매
        {
            openPanel();
        }
    }

    public void purchaseOK()
    {
        if(myCarrot >= priceBG[num])
        {
            myCarrot -= priceBG[num];
            carrot.text = myCarrot.ToString();
            state[num] = 1;
            check = true;
            closePanel();
        }
        else
        {
           // Debug.Log("소지 당근이 적습니다.");
            closePanel();
        }
    }

    public void purchaseCancel()
    {
        closePanel();
    }

    private void openPanel()
    {
        purchasePanel.SetActive(true);
        right.SetActive(false);
        left.SetActive(false);
        oriSet.SetActive(false);
    }

    private void closePanel()
    {
        purchasePanel.SetActive(false);
        right.SetActive(true);
        left.SetActive(true);
        oriSet.SetActive(true);
    }

    public void checkState()
    {
        if(state[num] == 0)
        {
            oriSet.SetActive(true);
            oriSet.GetComponent<Image>().sprite = setBG[0];
            oriState.GetComponent<SpriteRenderer>().sprite = stateBG[0];
        }

        else if (state[num] == 1)
        {
            oriSet.SetActive(true);
            oriSet.GetComponent<Image>().sprite = setBG[0];
            oriState.GetComponent<SpriteRenderer>().sprite = stateBG[1];
        }

        else if (state[num] == 2)
        {
            oriSet.SetActive(true);
            oriSet.GetComponent<Image>().sprite = setBG[1];
            oriState.GetComponent<SpriteRenderer>().sprite = price[num];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(check)
        {
            checkState();
            check = false;
        }

        if (touchChk)
        {
            right.SetActive(false);
            left.SetActive(false);
            oriSet.SetActive(false);
            oriState.SetActive(false);
            carrot.gameObject.SetActive(false);
            gameObject.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f);
            BackGround.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f);
        }

        if (!touchChk)
        {
            right.SetActive(true);
            left.SetActive(true);
            oriState.SetActive(true);
            carrot.gameObject.SetActive(true);
            check = true;
            gameObject.GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f);
            BackGround.GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f);
        }
    }
}
