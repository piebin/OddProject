using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameObject character;
    public Sprite[] characterSprite = new Sprite[46]; //0 비움
    private int[] randoms = new int[7];
    private int[] mynums = new int[7];
    private int[] ClickedB = new int[7];
    private int[] clickedS = new int[7];
    private float[] realY = new float[7];
    private bool start = false;
    public int lvNum;
    public Sprite[] sprites = new Sprite[20];
    public GameObject[] buttons = new GameObject[4];
    public GameObject[] saucesB = new GameObject[4];
    public GameObject[] Bigri = new GameObject[7];
    public GameObject BGroup;
    public GameObject sGroup;
    public GameObject[] re = new GameObject[7];
    public int num;
    public int snum;
    public int sauceN;
    public GameObject goBack, titlePanel, dark, loadingDown;
    public GameObject lvTimer;
    private int CharacterNum;
    private int IsclickedDduk = 0;
    public GameObject GuestBar;

    public GameObject ac1;
    public GameObject ac2;
    public GameObject ac3;
    public GameObject ac4;
    public GameObject ac5;
    public GameObject ac6;
    public GameObject ac7;
    public GameObject ac8;
    public GameObject ac9;

    public int TestAc;

    public static bool success = false;
    public GameObject sauceCh;
    bool exist1=false;
    public GameObject embox;
    public GameObject resetR;
    public GameObject multiBtnSound;
    public GameObject backGround;
    public GameObject longOrder, shortOrder;
    public Sprite[] BgSprites = new Sprite[9];
    public GameObject BGM2, openBtn;
    public GameObject spSauceB, spSaucePK, spSauceP, spSauceG;
    public int level = (ScoreManager.score / 100) + 1;

    // Start is called before the first frame update
    void Start()
    {
        titlePanel.SetActive(false);
        dark.SetActive(false);
        checkLv();
        guest();
        randomRice();
        num = 10;
        snum = 10;
        goBack.SetActive(true);

        //배경적용
        backGround.GetComponent<SpriteRenderer>().sprite = BgSprites[PlayerPrefs.GetInt("ing_key")];


        for (int i=0; i<realY.Length; i++)
        {
            realY[i] = Bigri[i].GetComponent<Transform>().position.y;
        }

        //업적 파일에 1이 없으면 실행
        if(PlayerPrefs.GetInt("achieve_key0")==0)
        {
            exist1 = true;
            PlayerPrefs.SetInt("achieve_key0", 1);
        }

        if (exist1)
            clearOne();
        //업적 텍스트 파일에 1이 없을 경우 업적 공개 효과인 Celarone함수 실행.

        Invoke("OpenBtnFalse", 1.6f);
        Invoke("FadeInvoke", 2.0f);
    }

    public void OpenBtnFalse()
    {
        openBtn.SetActive(false);
    }

    public void FadeInvoke()
    {
        StartCoroutine(Fade(character));
        StartCoroutine(Fade(shortOrder));
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(Fade(re[i]));
        }
        Invoke("showTime", 0.5f);
    }

    public void showTime()
    {
        GuestBar.SetActive(true);//시간 활성화
        GuestBar.GetComponent<circleBar>().currentValue = 0;
        num = 0;
        snum = 0;
        start = true;
    }

    public IEnumerator Fade(GameObject obj)
    {
        float duration = 1.0f;
        float currentTime = 0.0f;
        float alpha = 1.0f / duration;
        obj.SetActive(true);
        obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);

        while (currentTime < 1.0f)
        {
            currentTime += alpha * Time.deltaTime;
            obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, currentTime);
            yield return null;
        }
        obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield break;
    }

    public void clearOne()
    {
        ac1.SetActive(true);
        ac1.GetComponent<Animation>().Play();
        ac1.GetComponent<AudioSource>().Play();
    }
    public void clearTwo()
    {
        ac2.SetActive(true);
        ac2.GetComponent<Animation>().Play();
        ac2.GetComponent<AudioSource>().Play();
    }
    public void clearThree()
    {
        ac3.SetActive(true);
        ac3.GetComponent<Animation>().Play();
        ac3.GetComponent<AudioSource>().Play();
    }
    public void clearFour()
    {
        ac4.SetActive(true);
        ac4.GetComponent<Animation>().Play();
        ac4.GetComponent<AudioSource>().Play();
    }
    public void clearFive()
    {
        ac5.SetActive(true);
        ac5.GetComponent<Animation>().Play();
        ac5.GetComponent<AudioSource>().Play();
    }
    public void clearSix()
    {
        ac6.SetActive(true);
        ac6.GetComponent<Animation>().Play();
        ac6.GetComponent<AudioSource>().Play();
    }
    public void clearSeven()
    {
        ac7.SetActive(true);
        ac7.GetComponent<Animation>().Play();
        ac7.GetComponent<AudioSource>().Play();
    }
    public void clearEight()
    {
        ac8.SetActive(true);
        ac8.GetComponent<Animation>().Play();
        ac8.GetComponent<AudioSource>().Play();
    }
    public void clearNine()
    {
        ac9.SetActive(true);
        ac9.GetComponent<Animation>().Play();
        ac9.GetComponent<AudioSource>().Play();
    }


    public static IEnumerator FadeOut(GameObject source, float FadeTime)
    {
        AudioSource audioSource = source.GetComponent<AudioSource>();
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
    }

    public void goBackYes()
    {
        Time.timeScale = 1.0f;
        GuestBar.SetActive(false);
        PlayerPrefs.SetInt("go_title", 1);
        multiBtnSound.GetComponent<AudioSource>().Play();
        Vibration.Vibrate((long)20);
        loadingDown.SetActive(true);
        titlePanel.SetActive(false);
        StartCoroutine(FadeOut(BGM2, 1.5f));
        Invoke("loadTitle", 1.8f);
    }

    public void loadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void goBackNo()
    {
        lvTimer.GetComponent<Animator>().speed = 1.0f;
        lvTimer.GetComponent<Animator>().enabled = true;
        Time.timeScale = 1.0f;
        multiBtnSound.GetComponent<AudioSource>().Play();
        Vibration.Vibrate((long)20);
        //GuestBar.GetComponent<AudioSource>().Play();
        titlePanel.SetActive(false);
        dark.SetActive(false);
    }


    //엎질러진 소스 비활성화 함수
    public void NoSpP()
    {
        spSauceP.SetActive(false);
    }

    public void NoSpPK()
    {
        spSaucePK.SetActive(false);
    }

    public void NoSpB()
    {
        spSauceB.SetActive(false);
    }

    public void NoSpG()
    {
        spSauceG.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        if (TestAc == 1)
        {
            clearOne();
            PlayerPrefs.SetInt("achieve_key0", 1);
        }
        if (TestAc == 2)
        { clearTwo();
            PlayerPrefs.SetInt("achieve_key1", 1);
        }
        if (TestAc == 3)
        { clearThree();
            PlayerPrefs.SetInt("achieve_key2", 1);
        }
        if (TestAc == 4)
        { clearFour();
            PlayerPrefs.SetInt("achieve_key3", 1);
        }
        if (TestAc == 5)
        { clearFive();
            PlayerPrefs.SetInt("achieve_key4", 1);
        }
        if (TestAc == 6)
        { clearSix();
            PlayerPrefs.SetInt("achieve_key5", 1);
        }
        if (TestAc == 7)
        { clearSeven();
            PlayerPrefs.SetInt("achieve_key6", 1);
        }
        if (TestAc == 8)
        { clearEight();
            PlayerPrefs.SetInt("achieve_key7", 1);
        }
        if (TestAc == 9)
        { clearNine();
            PlayerPrefs.SetInt("achieve_key8", 1);
        }



        if (titlePanel.activeSelf == false)
        {
            Time.timeScale = 1.0f;
            embox.SetActive(false);
            resetR.GetComponent<ResetRice>().enabled = true;
            dark.SetActive(false);
            //this.enabled = true;
            //GuestBar.SetActive(true);
        }

        //버튼 누르는거
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);


            if (hit.collider != null)
            {
                if (hit.collider.gameObject == goBack && Input.GetMouseButtonUp(0))
                {
                    titlePanel.SetActive(true);
                    dark.SetActive(true);
                    lvTimer.GetComponent<Animator>().speed = 0.0f;
                    lvTimer.GetComponent<Animator>().enabled = false;
                    Time.timeScale = 0.0f;
                    embox.SetActive(true);
                    resetR.GetComponent<ResetRice>().enabled = false;
                    goBack.GetComponent<AudioSource>().Play();
                    //this.enabled = false;
                    //GuestBar.SetActive(false);
                }

                if (hit.collider.gameObject == buttons[0] && num < lvNum)
                {
                    mynums[num] = 0;
                    ClickedB[num] = mynums[num]; //클릭한거 숫자 저장해둠.
                    Bigrice(num, mynums[num], true);
                    StopCoroutine("RiceDown");
                    //Bigri[num].GetComponent<Animation>().Play();
                    buttons[0].GetComponent<AudioSource>().Play();
                    num++;
                }
                else if (hit.collider.gameObject == buttons[1] && num < lvNum)
                {
                    mynums[num] = 1;
                    ClickedB[num] = mynums[num];
                    Bigrice(num, mynums[num], true);
                    StopCoroutine("RiceDown");
                    //Bigri[num].GetComponent<Animation>().Play();
                    buttons[1].GetComponent<AudioSource>().Play();
                    num++;
                }
                else if (hit.collider.gameObject == buttons[2] && num < lvNum)
                {
                    mynums[num] = 2;
                    ClickedB[num] = mynums[num];
                    Bigrice(num, mynums[num], true);
                    StopCoroutine("RiceDown");
                    //Bigri[num].GetComponent<Animation>().Play();
                    buttons[2].GetComponent<AudioSource>().Play();
                    num++;
                }
                else if (hit.collider.gameObject == buttons[3] && num < lvNum)
                {
                    mynums[num] = 3;
                    ClickedB[num] = mynums[num];
                    Bigrice(num, mynums[num], true);
                    StopCoroutine("RiceDown");
                    //Bigri[num].GetComponent<Animation>().Play();
                    buttons[3].GetComponent<AudioSource>().Play();
                    num++;
                }

                //업적 4번

                if(hit.collider.gameObject == buttons[0] || hit.collider.gameObject == buttons[1] || hit.collider.gameObject == buttons[2] || hit.collider.gameObject == buttons[3])
                {
                    IsclickedDduk = 1;
                }

                if((hit.collider.gameObject == saucesB[0] || hit.collider.gameObject == saucesB[1] || hit.collider.gameObject == saucesB[1] || hit.collider.gameObject == saucesB[3])&&IsclickedDduk==0)
                {
                    if (PlayerPrefs.GetInt("achieve_key3") == 0)
                    {
                        Debug.Log("achieve4 clear");
                        clearFour();
                        PlayerPrefs.SetInt("achieve_key3", 1);
                    }
                }

                if(hit.collider.gameObject==saucesB[0] && IsclickedDduk == 0)//보라
                {
                    spSauceP.SetActive(true);
                    IsclickedDduk = 0;
                    Invoke("NoSpP", 0.3f);
                }

                if (hit.collider.gameObject == saucesB[1] && IsclickedDduk == 0)//분홍
                {
                    spSaucePK.SetActive(true);
                    IsclickedDduk = 0;
                    Invoke("NoSpPK", 0.3f);
                }

                if (hit.collider.gameObject == saucesB[2] && IsclickedDduk == 0)//파랑
                {
                    spSauceB.SetActive(true);
                    IsclickedDduk = 0;
                    Invoke("NoSpB", 0.3f);
                }

                if (hit.collider.gameObject == saucesB[3] && IsclickedDduk == 0)//초록
                {
                    spSauceG.SetActive(true);
                    IsclickedDduk = 0;
                    Invoke("NoSpG", 0.3f);
                }


                //소스버튼 눌렀을 때
                //모양4개, 색 4개->16개 if
                if (hit.collider.gameObject == saucesB[0] && num > snum) //보라색
                {
                    saucesB[0].GetComponent<AudioSource>().Play();
                    for (int i=0; i<num; i++)//지금까지 누른 모양 확인
                    {
                        //모양 4개 경우 나눠서 다른 스프라이트 적용
                        if (mynums[snum] == 0)
                        {
                            Bigrice(snum, 4, false);
                            clickedS[snum] = 4;
                        }

                        if (mynums[snum] == 1)
                        {
                            Bigrice(snum, 8, false);
                            clickedS[snum] = 8;
                        }

                        if (mynums[snum] == 2)
                        {
                            Bigrice(snum, 12, false);
                            clickedS[snum] = 12;
                        }

                        if (mynums[snum] == 3)
                        {
                            Bigrice(snum, 16, false);
                            clickedS[snum] = 16;
                        }
                    }
                    snum++; //소스 버튼을 누른 횟수
                }

                if (hit.collider.gameObject == saucesB[1] && num > snum) //분홍색
                {
                    saucesB[1].GetComponent<AudioSource>().Play();
                    for (int i = 0; i < num; i++)//지금까지 누른 모양 확인
                    {
                        //모양 4개 경우 나눠서 다른 스프라이트 적용
                        if (mynums[snum] == 0)
                        {
                            Bigrice(snum, 5, false);
                            clickedS[snum] = 5;
                        }

                        if (mynums[snum] == 1)
                        {
                            Bigrice(snum, 9, false);
                            clickedS[snum] = 9;
                        }

                        if (mynums[snum] == 2)
                        {
                            Bigrice(snum, 13, false);
                            clickedS[snum] = 13;
                        }

                        if (mynums[snum] == 3)
                        {
                            Bigrice(snum, 17, false);
                            clickedS[snum] = 17;
                        }

                    }
                    snum++; //소스 버튼을 누른 횟수
                }

                if (hit.collider.gameObject == saucesB[2] && num > snum) //파란색
                {
                    saucesB[2].GetComponent<AudioSource>().Play();
                    for (int i = 0; i < num; i++)//지금까지 누른 모양 확인
                    {
                        //모양 4개 경우 나눠서 다른 스프라이트 적용
                        if (mynums[snum] == 0)
                        {
                            Bigrice(snum, 6, false);
                            clickedS[snum] = 6;
                        }

                        if (mynums[snum] == 1)
                        {
                            Bigrice(snum, 10, false);
                            clickedS[snum] = 10;
                        }

                        if (mynums[snum] == 2)
                        {
                            Bigrice(snum, 14, false);
                            clickedS[snum] = 14;
                        }

                        if (mynums[snum] == 3)
                        {
                            Bigrice(snum, 18, false);
                            clickedS[snum] = 18;
                        }
                    }
                    snum++; //소스 버튼을 누른 횟수
                }

                if (hit.collider.gameObject == saucesB[3] && num > snum) //초록색
                {
                    saucesB[3].GetComponent<AudioSource>().Play();
                    for (int i = 0; i < num; i++)//지금까지 누른 모양 확인
                    {
                        //모양 4개 경우 나눠서 다른 스프라이트 적용
                        if (mynums[snum] == 0)
                        {
                            Bigrice(snum, 7, false);
                            clickedS[snum] = 7;
                        }

                        if (mynums[snum] == 1)
                        {
                            Bigrice(snum, 11, false);
                            clickedS[snum] = 11;
                        }

                        if (mynums[snum] == 2)
                        {
                            Bigrice(snum, 15, false);
                            clickedS[snum] = 15;
                        }

                        if (mynums[snum] == 3)
                        {
                            Bigrice(snum, 19, false);
                            clickedS[snum] = 19;
                        }
                    }
                    snum++; //소스 버튼을 누른 횟수
                }


                //클릭한거랑 랜덤수랑 비교해서 같은지 확인
                if (num >= lvNum && snum >= lvNum && snum>2)
                {
                    int sn = 0;

                    for (int i = 0; i < lvNum; i++)
                    {
                        /*if(i == lvNum - 1 && clickedS[i] == randoms[i])
                        {
                            sn++;
                            Debug.Log("sn is " + sn);
                            Debug.Log("lvNum is " + lvNum);

                        }*/

                        if (clickedS[i] == randoms[i])
                        {
                            sn++;
                        }

                        /*if (clickedS[i] == randoms[i])
                            continue;*/
                    }

                    if (sn == lvNum)
                    {
                        ScoreManager.score += 10;
                        //Vibration.Cancel();
                        //Vibration.Vibrate((long)400);
                        //GuestBar.GetComponent<AudioSource>().Stop();
                        //Invoke("TimerSound", 0.8f);
                        gameObject.GetComponent<AudioSource>().Play();
                        success = true;

                        ChangeGuest();
                    }

                    //checkLv();
                }
            }
        }
    }

    //public void TimerSound()
    //{
    //    GuestBar.GetComponent<AudioSource>().Play();
    //}

    public void AnActive()
    {
        character.SetActive(false);
        for (int i = 0; i < Bigri.Length; i++)
        {
            Bigri[i].SetActive(false);
            re[i].SetActive(false);
        }
        checkLv();
    }

    public void ChangeGuest()
    {
        sauceCh.GetComponent<BoxCollider2D>().enabled = false;

        Invoke("AnActive", 0.5f);
        Invoke("guest", 0.5f);
        Invoke("sauceChange", 0.5f);
        Invoke("randomRice", 0.6f);
        Invoke("sauceChON", 0.6f);
    }

    public void sauceChON()
    {
        sauceCh.GetComponent<BoxCollider2D>().enabled = true;
    }

    //버튼 창을 떡 시작으로 바꿈.
    public void sauceChange()
    {
        sauceCh.GetComponent<SauceChange>().Sbutton.GetComponent<SpriteRenderer>().sprite = sauceCh.GetComponent<SauceChange>().sauceB;
        for (int i = 0; i < 4; i++)
        {
            sauceCh.GetComponent<SauceChange>().buttons[i].SetActive(true);
            //Debug.Log("Activate Rice");
        }//떡 버튼 활성화
        for (int i = 4; i < 8; i++)
        {
            sauceCh.GetComponent<SauceChange>().buttons[i].SetActive(false);
            //Debug.Log("DeActivate Suace");
        }//소스 버튼 비활성화
    }

    public void guest()
    {
        CharacterNum = Random.Range(1, 46); //함수가 실행될때마다 랜덤 수 초기화     
        character.GetComponent<SpriteRenderer>().sprite = characterSprite[CharacterNum];

        //업적 6번 우주복

        if(CharacterNum==1)
            PlayerPrefs.SetInt("achieve_key5-1", 1);
        if (CharacterNum == 4)
            PlayerPrefs.SetInt("achieve_key5-2", 1);
        if (CharacterNum == 7)
            PlayerPrefs.SetInt("achieve_key5-3", 1);
        if (CharacterNum == 10)
            PlayerPrefs.SetInt("achieve_key5-4", 1);
        if (CharacterNum == 13)
            PlayerPrefs.SetInt("achieve_key5-5", 1);
        if (CharacterNum == 16)
            PlayerPrefs.SetInt("achieve_key5-6", 1);
        if (CharacterNum == 19)
            PlayerPrefs.SetInt("achieve_key5-7", 1);
        if (CharacterNum == 22)
            PlayerPrefs.SetInt("achieve_key5-8", 1);
        if (CharacterNum == 25)
            PlayerPrefs.SetInt("achieve_key5-9", 1);
        if (CharacterNum == 28)
            PlayerPrefs.SetInt("achieve_key5-10", 1);
        if (CharacterNum == 31)
            PlayerPrefs.SetInt("achieve_key5-11", 1);
        if (CharacterNum == 34)
            PlayerPrefs.SetInt("achieve_key5-12", 1);
        if (CharacterNum == 37)
            PlayerPrefs.SetInt("achieve_key5-13", 1);
        if (CharacterNum == 40)
            PlayerPrefs.SetInt("achieve_key5-14", 1);
        if (CharacterNum == 43)
            PlayerPrefs.SetInt("achieve_key5-15", 1);

        if(PlayerPrefs.GetInt("achieve_key5") == 0 && PlayerPrefs.GetInt("achieve_key5-1")==1 && PlayerPrefs.GetInt("achieve_key5-2") == 1 && PlayerPrefs.GetInt("achieve_key5-3") == 1 
            && PlayerPrefs.GetInt("achieve_key5-4") == 1 && PlayerPrefs.GetInt("achieve_key5-5") == 1 && PlayerPrefs.GetInt("achieve_key5-6") == 1 
            && PlayerPrefs.GetInt("achieve_key5-7") == 1 && PlayerPrefs.GetInt("achieve_key5-8") == 1 && PlayerPrefs.GetInt("achieve_key5-9") == 1 
            && PlayerPrefs.GetInt("achieve_key5-10") == 1 && PlayerPrefs.GetInt("achieve_key5-11") == 1 && PlayerPrefs.GetInt("achieve_key5-12") == 1 
            && PlayerPrefs.GetInt("achieve_key5-13") == 1 && PlayerPrefs.GetInt("achieve_key5-14") == 1 && PlayerPrefs.GetInt("achieve_key5-15") == 1)
        {
            Debug.Log("achieve6 clear");
            clearSix();
            PlayerPrefs.SetInt("achieve_key5", 1);
        }



        //업적 7번 일상복a

        if (CharacterNum == 2)
            PlayerPrefs.SetInt("achieve_key6-1", 1);
        if (CharacterNum == 5)
            PlayerPrefs.SetInt("achieve_key6-2", 1);
        if (CharacterNum == 8)
            PlayerPrefs.SetInt("achieve_key6-3", 1);
        if (CharacterNum == 11)
            PlayerPrefs.SetInt("achieve_key6-4", 1);
        if (CharacterNum == 14)
            PlayerPrefs.SetInt("achieve_key6-5", 1);
        if (CharacterNum == 17)
            PlayerPrefs.SetInt("achieve_key6-6", 1);
        if (CharacterNum == 20)
            PlayerPrefs.SetInt("achieve_key6-7", 1);
        if (CharacterNum == 23)
            PlayerPrefs.SetInt("achieve_key6-8", 1);
        if (CharacterNum == 26)
            PlayerPrefs.SetInt("achieve_key6-9", 1);
        if (CharacterNum == 29)
            PlayerPrefs.SetInt("achieve_key6-10", 1);
        if (CharacterNum == 32)
            PlayerPrefs.SetInt("achieve_key6-11", 1);
        if (CharacterNum == 35)
            PlayerPrefs.SetInt("achieve_key6-12", 1);
        if (CharacterNum == 38)
            PlayerPrefs.SetInt("achieve_key6-13", 1);
        if (CharacterNum == 41)
            PlayerPrefs.SetInt("achieve_key6-14", 1);
        if (CharacterNum == 44)
            PlayerPrefs.SetInt("achieve_key6-15", 1);

        if (PlayerPrefs.GetInt("achieve_key6") == 0 && PlayerPrefs.GetInt("achieve_key6-1") == 1 && PlayerPrefs.GetInt("achieve_key6-2") == 1 && PlayerPrefs.GetInt("achieve_key6-3") == 1
            && PlayerPrefs.GetInt("achieve_key6-4") == 1 && PlayerPrefs.GetInt("achieve_key6-5") == 1 && PlayerPrefs.GetInt("achieve_key6-6") == 1
            && PlayerPrefs.GetInt("achieve_key6-7") == 1 && PlayerPrefs.GetInt("achieve_key6-8") == 1 && PlayerPrefs.GetInt("achieve_key6-9") == 1
            && PlayerPrefs.GetInt("achieve_key6-10") == 1 && PlayerPrefs.GetInt("achieve_key6-11") == 1 && PlayerPrefs.GetInt("achieve_key6-12") == 1
            && PlayerPrefs.GetInt("achieve_key6-13") == 1 && PlayerPrefs.GetInt("achieve_key6-14") == 1 && PlayerPrefs.GetInt("achieve_key6-15") == 1)
        {
            Debug.Log("achieve7 clear");
            clearSeven();
            PlayerPrefs.SetInt("achieve_key6", 1);
        }


        //업적 8번

        if (CharacterNum == 7)
            PlayerPrefs.SetInt("achieve_key7-1", 1);
        if (CharacterNum == 8)
            PlayerPrefs.SetInt("achieve_key7-2", 1);
        if (CharacterNum == 9)
            PlayerPrefs.SetInt("achieve_key7-3", 1);


        if (PlayerPrefs.GetInt("achieve_key7") == 0 && PlayerPrefs.GetInt("achieve_key7-1") == 1 && PlayerPrefs.GetInt("achieve_key7-2") == 1 && PlayerPrefs.GetInt("achieve_key7-3") == 1)
        {
            Debug.Log("achieve8 clear");
            clearEight();
            PlayerPrefs.SetInt("achieve_key7", 1);
        }

        if (start)
        {
            character.SetActive(true);
            GuestBar.SetActive(true);//시간 활성화
            GuestBar.GetComponent<circleBar>().currentValue = 0; //시간을 0으로 초기화해줌
        }
        num = 0;
        snum = 0;
    }

    public void checkLv()
    {
        int randomInt = Random.Range(0, 2);
        level = (ScoreManager.score / 100) + 1;

        if(PlayerPrefs.GetInt("game_over")==1)
        {
            if(level<4)
            {
                if(PlayerPrefs.GetInt("achieve_key8") == 0)
                {
                    Debug.Log("achieve9 clear");
                    clearNine();
                    PlayerPrefs.SetInt("achieve_key8", 1);
                }
            }
        }//업적 9번 달성

        if(level==12)
        {
            if(PlayerPrefs.GetInt("achieve_key4") ==0)
            {
                Debug.Log("achieve5 clear");
                clearFive();
                PlayerPrefs.SetInt("achieve_key4", 1);
            }
        }
        //업적 5번 달성

        switch(level)
        {
            case 1:
                lvNum = 3;
                break;
            case 2:
            case 3:
            case 4:
                if (randomInt == 0)
                     lvNum = 3;
                else
                     lvNum = 4;
                break;
            case 5:
            case 6:
                lvNum = 4;
                break;
            case 7:
            case 8:
                if (randomInt == 0)
                    lvNum = 4;
                else
                    lvNum = 5;
                break;
            case 9:
            case 10:
                lvNum = 5;
                break;
            case 11:
            case 12:
                if (randomInt == 0)
                    lvNum = 5;
                else
                    lvNum = 6;
                break;
            case 13:
                lvNum = 6;
                break;
            case 14:
            case 15:
            default:
                if (randomInt == 0)
                    lvNum = 6;
                else
                    lvNum = 7;
                break;
        }
        if(lvNum < 5)
        {
            if(start) shortOrder.SetActive(true);
            longOrder.SetActive(false);
        }
        else
        {
            longOrder.SetActive(true);
            shortOrder.SetActive(false);
        }
        BGroup.transform.position = new Vector3(0, -lvNum / 1.8f, 0);
        sGroup.transform.position = new Vector3(0, -lvNum / 3.5f, 0);
    }

    public void randomRice()
    {
        SpriteRenderer[] ren = new SpriteRenderer[lvNum];
        for(int i = 0; i < lvNum; i++)
        {
            ren[i] = re[i].GetComponent<SpriteRenderer>();
            randoms[i] = Random.Range(4, 19);
            ren[i].sprite = sprites[randoms[i]];
            if(start) re[i].SetActive(true);
        }
        //스프라이트 받아옴
        //랜덤숫자들->얘랑 누른거랑 비교하기.

        //Debug.Log("랜덤 수 생성" + randoms[0] + "and" + randoms[1]);
        success = false;
        //Debug.Log("num : " + lvNum);
    }

    public IEnumerator RiceDown(GameObject obj, float realY)
    {
        float duration = 0.4f;
        float currentTime = 0.0f;
        float currentTime2 = 0.0f;
        float target = 4.0f;
        float objY = realY + target;
        float offset = (target - currentTime) / duration;
        float alpha = 1.0f / duration;
        obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);

        while (currentTime < target)
        {
            currentTime += offset * Time.deltaTime;
            currentTime2 += alpha * Time.deltaTime;
            obj.GetComponent<Transform>().position = new Vector3(-3.9f, objY - currentTime, 0);
            obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, currentTime2);
            yield return null;
        }
        obj.GetComponent<Transform>().position = new Vector3(-3.9f, objY - target, 0);
        obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        yield break;
    }

    private void Bigrice(int a, int b, bool chk)
    {
        SpriteRenderer[] big = new SpriteRenderer[lvNum];
        for (int i = 0; i < lvNum; i++)
        {
            big[i] = Bigri[i].GetComponent<SpriteRenderer>();
        }

        switch(a)
        {
            default:
                big[a].sprite = sprites[b];
                Bigri[a].SetActive(true);
                if (chk == true) StartCoroutine(RiceDown(Bigri[a], realY[a]));
                break;
        }
    }
}
