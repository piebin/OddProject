using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScrollView : MonoBehaviour
{
    public Sprite[] sprite = new Sprite[9];
    public Sprite lockSprite;
    public GameObject content;
    private int num = 0, myCarrot;
    private int[] xPos = { 45, -150, -345, -536, -730, -922, -1113, -1306, -1500 };
    //private int[] clickPos = { 62, -227, -515, -805, -1093, -1382, -1670, -1959, -2248 }; //1.5 1.5
    private float[] clickPos = { 67.8f, -249.7f, -565, -880.2f, -1196, -1511, -1826, -2141, -2458 }; //1.64 1.82
    private int clickYPos = 19;
    private int yPos = 10;

    public Sprite[] price = new Sprite[9]; //배경별 가격
    public Sprite[] stateBG = new Sprite[2]; //0:적용중 1:구매완료
    public Sprite[] setBG = new Sprite[2]; //0:적용 1:구매
    public AudioSource[] audioSource = new AudioSource[3]; //1:적용, 구매  2:멀티
    public GameObject oriState, oriSet, BackGround;
    public GameObject purchasePanel, right, left, back;
    public Text carrot, clickText;
    private bool check = false;
    private bool panel = false;
    public static bool touchChk = false;
    private int[] priceBG = new int[9];
    private int[] state = new int[9]; //0:적용중 1:구매완료 2:가격 3:자물쇠

    string buyTh = "Assets/TextFiles/buy";

    // Start is called before the first frame update
    void Start()
    {
        clickText.gameObject.SetActive(false);
        for(int i=0; i<sprite.Length; i++)
        {
            if (sprite[i] == null)
            {
                sprite[i] = lockSprite;
                state[i] = 3;
            }

            else state[i] = 2;
            content.transform.GetChild(i).GetComponent<Image>().sprite = sprite[i];
        }
        state[0] = 0;
        priceBG[0] = 50000; //수정 필요
        priceBG[1] = 50000; //수정 필요
        priceBG[4] = 60000; //수정 필요

        check = true;
        purchasePanel.SetActive(false);
        Int32.TryParse(carrot.text, out myCarrot);
    }

    public void ScrollLeft()
    {
        if (num == 0)
            num -= 0;
        else
        {
            num -= 1;
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos[num], yPos);
            check = true;
        }
    }

    public void ScrollRight()
    {
        if (num == sprite.Length - 1)
            num += 0;
        else
        {
            num += 1;
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos[num], yPos);
            check = true;
        }
    }

    public void setBtn()
    {
        audioSource[1].Play();

        if (state[num] == 0) { }

        else if (state[num] == 1) //적용
        {
            for (int i = 0; i < state.Length; i++)
            {
                if (state[i] == 0)
                    state[i] = 1;
            }
            state[num] = 0;
            check = true;
        }

        else if (state[num] == 2) //구매
        {
            openPanel();
        }

        else if (state[num] == 3) { }
    }

    public void purchaseOK()
    {
        audioSource[2].Play();

        if (myCarrot >= priceBG[num])
        {
            myCarrot -= priceBG[num];
            carrot.text = myCarrot.ToString();
            state[num] = 1;
            check = true;
            closePanel();

            StreamWriter buywriter;
            buywriter = File.AppendText(buyTh);
            buywriter.WriteLine("\n" + num);
            buywriter.Close();

        }//구매완료
        else
        {
            Debug.Log("소지 당근이 적습니다.");
            closePanel();
        }
    }

    public void purchaseCancel()
    {
        audioSource[2].Play();
        closePanel();
    }

    private void openPanel()
    {
        panel = true;
        purchasePanel.SetActive(true);
        right.SetActive(false);
        left.SetActive(false);
        oriSet.SetActive(false);
        back.SetActive(false);
    }

    private void closePanel()
    {
        panel = false;
        purchasePanel.SetActive(false);
        right.SetActive(true);
        left.SetActive(true);
        oriSet.SetActive(true);
        back.SetActive(true);
    }

    public void checkState()
    {

        FileStream buyR = new FileStream(buyTh, FileMode.Open);
        StreamReader buyReader = new StreamReader(buyR);
        string buyLine = null;
        //int buynum = 0;

        while ((buyLine = buyReader.ReadLine()) != null)
        {
            //if(buyLine=="1")
                //state[num] = 1;
        }

        buyReader.Close();


        if (state[num] == 0)
        {
            oriSet.SetActive(true);
            oriState.SetActive(true);
            oriSet.GetComponent<Image>().sprite = setBG[0];
            oriState.GetComponent<SpriteRenderer>().sprite = stateBG[0];
        }

        else if (state[num] == 1)
        {
            oriSet.SetActive(true);
            oriState.SetActive(true);
            oriSet.GetComponent<Image>().sprite = setBG[0];
            oriState.GetComponent<SpriteRenderer>().sprite = stateBG[1];
        }

        else if (state[num] == 2)
        {
            oriSet.SetActive(true);
            oriState.SetActive(true);
            oriSet.GetComponent<Image>().sprite = setBG[1];
            oriState.GetComponent<SpriteRenderer>().sprite = price[num];
        }

        else if (state[num] == 3)
        {
            oriSet.SetActive(false);
            oriState.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            checkState();
            check = false;
        }

        if(panel)
        {
            openPanel();
        }

        else if (touchChk)
        {
            right.SetActive(false);
            left.SetActive(false);
            oriSet.SetActive(false);
            oriState.SetActive(false);
            carrot.gameObject.SetActive(false);
            back.SetActive(false);
            clickText.gameObject.SetActive(true);
            gameObject.GetComponent<Transform>().localScale = new Vector3(1.64f, 1.82f);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(clickPos[num], clickYPos);
            //BackGround.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f);
        }

        else if (!touchChk)
        {
            right.SetActive(true);
            left.SetActive(true);
            carrot.gameObject.SetActive(true);
            back.SetActive(true);
            clickText.gameObject.SetActive(false);
            check = true;
            gameObject.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos[num], yPos);
            //BackGround.GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f);
        }
    }
}
