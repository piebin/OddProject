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
    private float[] clickPos = { 66.8f, -248, -564.1f, -879.6f, -1195.5f, -1511, -1827, -2143, -2458 }; //1.64 1.82
    private int clickYPos = 19;
    private int yPos = 3;

    public Sprite[] price = new Sprite[9]; //배경별 가격
    public Sprite[] stateBG = new Sprite[2]; //0:적용중 1:구매완료
    public Sprite[] setBG = new Sprite[2]; //0:적용 1:구매
    public AudioSource[] audioSource = new AudioSource[3]; //1:적용, 구매  2:멀티
    public GameObject oriState, oriSet, BackGround;
    public GameObject purchasePanel, setPanel, alreadySetPanel, right, left, back;
    public Text carrot, clickText;
    private bool check = false;
    private bool panel1 = false, panel2 = false, panel3 = false;
    public static bool touchChk = false;
    private int[] priceBG = new int[9];
    private int[] state = new int[9]; //0:적용중 1:구매완료 2:가격 3:자물쇠

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
        //state[0] = 0;
        state[PlayerPrefs.GetInt("ing_key")] = 0;
        priceBG[0] = 50000; //수정 필요
        priceBG[1] = 50000; //수정 필요
        priceBG[4] = 60000; //수정 필요

        check = true;
        purchasePanel.SetActive(false);
        setPanel.SetActive(false);
        alreadySetPanel.SetActive(false);
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

        if (state[num] == 0) 
        {
            openPanel(alreadySetPanel);
        }

        else if (state[num] == 1) //적용
        {
            //for (int i = 0; i < state.Length; i++)
            //{
            //    if (state[i] == 0)
            //        state[i] = 1;
            //}
            //
            ////state[num] = 0;
            ////Debug.Log("clicked");
            //PlayerPrefs.SetInt("ing_key", num);
            //state[PlayerPrefs.GetInt("ing_key")] = 0;
            //
            //check = true;
            openPanel(setPanel);
            //PlayerPrefs.SetInt("ing_key", num);
            Debug.Log("ing is" + PlayerPrefs.GetInt("ing_key"));
        }

        else if (state[num] == 2) //구매
        {
            openPanel(purchasePanel);
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

            switch(num)
            {
                case 0:
                    PlayerPrefs.SetInt("buy_key0", 1);
                    break;
                case 1:
                    PlayerPrefs.SetInt("buy_key1", 1);
                    break;
                case 2:
                    PlayerPrefs.SetInt("buy_key2", 1);
                    break;
                case 3:
                    PlayerPrefs.SetInt("buy_key3", 1);
                    break;
                case 4:
                    PlayerPrefs.SetInt("buy_key4", 1);
                    break;
                case 5:
                    PlayerPrefs.SetInt("buy_key5", 1);
                    break;
                case 6:
                    PlayerPrefs.SetInt("buy_key6", 1);
                    break;
                case 7:
                    PlayerPrefs.SetInt("buy_key7", 1);
                    break;
                case 8:
                    PlayerPrefs.SetInt("buy_key8", 1);
                    break;

            }
            //텍스트 파일에 num입력->구매한 num의 번호를 입력.

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

    public void setOK()
    {
        audioSource[2].Play();
        for (int i = 0; i < state.Length; i++)
        {
            if (state[i] == 0)
                state[i] = 1;
        }
        
        //state[num] = 0;
        //Debug.Log("clicked");
        PlayerPrefs.SetInt("ing_key", num);
        state[PlayerPrefs.GetInt("ing_key")] = 0;
        
        check = true;
        closePanel();
    }

    public void setCancel()
    {
        audioSource[2].Play();
        closePanel();
    }

    private void openPanel(GameObject nowPanel)
    {
        if (nowPanel == purchasePanel)  panel1 = true;
        else if (nowPanel == setPanel)  panel2 = true;
        else if (nowPanel == alreadySetPanel) panel3 = true;
        nowPanel.SetActive(true);
        right.SetActive(false);
        left.SetActive(false);
        oriSet.SetActive(false);
        back.SetActive(false);
    }

    private void closePanel()
    {
        panel1 = false;
        panel2 = false;
        panel3 = false;
        setPanel.SetActive(false);
        purchasePanel.SetActive(false);
        alreadySetPanel.SetActive(false);
        right.SetActive(true);
        left.SetActive(true);
        oriSet.SetActive(true);
        back.SetActive(true);
    }

    public void checkState()
    {
        state[PlayerPrefs.GetInt("ing_key")] = 0;

        if (PlayerPrefs.GetInt("buy_key0") == 1 && num != PlayerPrefs.GetInt("ing_key"))
             state[0] = 1;

        if (PlayerPrefs.GetInt("buy_key1") == 1 && num != PlayerPrefs.GetInt("ing_key"))
            state[1] = 1;

        if (PlayerPrefs.GetInt("buy_key2") == 1 && num != PlayerPrefs.GetInt("ing_key"))
            state[2] = 1;

        if (PlayerPrefs.GetInt("buy_key3") == 1 && num != PlayerPrefs.GetInt("ing_key"))
            state[3] = 1;

        if (PlayerPrefs.GetInt("buy_key4") == 1 && num != PlayerPrefs.GetInt("ing_key"))
            state[4] = 1;

        if (PlayerPrefs.GetInt("buy_key5") == 1 && num != PlayerPrefs.GetInt("ing_key"))
            state[5] = 1;

        if (PlayerPrefs.GetInt("buy_key6") == 1 && num != PlayerPrefs.GetInt("ing_key"))
            state[6] = 1;

        if (PlayerPrefs.GetInt("buy_key7") == 1 && num != PlayerPrefs.GetInt("ing_key"))
            state[7] = 1;

        if (PlayerPrefs.GetInt("buy_key8") == 1 && num != PlayerPrefs.GetInt("ing_key"))
            state[8] = 1;


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

        if(panel1 || panel2 || panel3)
        {
            if (panel1) openPanel(purchasePanel);
            else if (panel2) openPanel(setPanel);
            else if (panel3) openPanel(alreadySetPanel);
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
