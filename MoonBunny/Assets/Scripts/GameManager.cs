using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameObject[] character = new GameObject[3];
    private int[] randoms = new int[7];
    private int[] mynums = new int[7];
    private int[] ClickedB = new int[7];
    private int[] clickedS = new int[7];
    private int lvNum;
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
    public GameObject goBack, titlePanel;
    private int CharacterNum;
    public GameObject GuestBar;
    public GameObject Ab1;
    public static bool success = false;
    public GameObject sauceCh;
    bool exist1=false;
    public GameObject embox;
    public GameObject resetR;

    // Start is called before the first frame update
    void Start()
    {
        titlePanel.SetActive(false);
        checkLv();
        Invoke("guest", 1);
        Invoke("randomRice", 1);
        num = 0;
        snum = 0;
        goBack.SetActive(true);


        //업적 파일에 1이 없으면 실행

        if(PlayerPrefs.GetInt("achieve_key0")==0)
        {
            exist1 = true;
            PlayerPrefs.SetInt("achieve_key0", 1);
        }


        if (exist1)
            clearOne();
        //업적 텍스트 파일에 1이 없을 경우 업적 공개 효과인 Celarone함수 실행.

    }

    public void clearOne()
    {
        Ab1.SetActive(true);
        Ab1.GetComponent<Animation>().Play();
        Ab1.GetComponent<AudioSource>().Play();

        //업적 텍스트 파일에 업적 공개 효과가 실행됐음을 알리기 위해 텍스트 파일에 "1" 입력.
        //여기서 "1"은 1번 업적을 의미함.

        //Destroy(Ab1, 10f);

    }

    public void goBackYes()
    {
        SceneManager.LoadScene("Title");
    }

    public void goBackNo()
    {
        titlePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (titlePanel.activeSelf == false)
        {
            Time.timeScale = 1.0f;
            embox.SetActive(false);
            resetR.GetComponent<ResetRice>().enabled = true;
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
                if(hit.collider.gameObject == goBack)
                {
                    titlePanel.SetActive(true);
                    Time.timeScale = 0.0f;
                    embox.SetActive(true);
                    resetR.GetComponent<ResetRice>().enabled = false;
                    goBack.GetComponent<AudioSource>().Play();
                    //this.enabled = false;
                    //GuestBar.SetActive(false);
                }

                if(hit.collider.gameObject == embox)
                {

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

                //소스버튼 눌렀을 때
                //모양4개, 색 4개->16개 if
                if(hit.collider.gameObject == saucesB[0] && num > snum) //보라색
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

                if (hit.collider.gameObject == saucesB[1] && num > snum) //빨간색
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

                if (hit.collider.gameObject == saucesB[2] && num > snum) //노란색
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
                if (num >= lvNum && snum >= lvNum)
                {
                    int sn = 0;

                    for (int i = 0; i < lvNum; i++)
                    {
/*                        if(i == lvNum - 1 && clickedS[i] == randoms[i])
                        {
                            sn++;
                            Debug.Log("sn is " + sn);
                            Debug.Log("lvNum is " + lvNum);

                        }*/

                        if (clickedS[i] == randoms[i])
                        {
                            sn++;
                        }

                        if (clickedS[i] == randoms[i])
                            continue;
                    }

                    if (sn == lvNum)
                    {
                        ScoreManager.score += 10;
                        Camera.main.GetComponent<AudioSource>().Play();
                        success = true;
                        ChangeGuest();
                        num = 0;
                        snum = 0;
                    }

                    //checkLv();
                }
            }
        }
    }

    public void AnActive()
    {
        for(int i=0; i<3; i++)
        {
            if (character[i].activeSelf)
                character[i].SetActive(false);
        } //랜덤 캐릭터중 활성화된것만 찾아서 비활성화시킴

        for (int i = 0; i < Bigri.Length; i++)
        {
            Bigri[i].SetActive(false);
            re[i].SetActive(false);
        }
        checkLv();
    }

    public void ChangeGuest()
    {
        Invoke("AnActive", 0.5f);
        Invoke("guest", 0.5f);
        Invoke("sauceChange", 0.5f);
        Invoke("randomRice", 0.6f);
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
        CharacterNum = Random.Range(0, 3); //함수가 실행될때마다 랜덤 수 초기화
        character[CharacterNum].SetActive(true); //랜덤 활성화
        GuestBar.SetActive(true);//시간 활성화
        GuestBar.GetComponent<circleBar>().currentValue = 0; //시간을 0으로 초기화해줌
        //애니메이션 활성화
    }

    public void checkLv()
    {
        int randomInt = Random.Range(0, 2);
        int level = (ScoreManager.score / 100) + 1;

        if(PlayerPrefs.GetInt("game_over")==1)
        {
            if(level<4)
            {
                if(PlayerPrefs.GetInt("achieve_key8") == 0)
                {
                    Debug.Log("achieve9 clear");
                    clearOne();
                    PlayerPrefs.SetInt("achieve_key8", 1);
                }
            }
        }//업적 9번 달성





        if(level==12)
        {
            if(PlayerPrefs.GetInt("achieve_key4") ==0)
            {
                Debug.Log("achieve5 clear");
                clearOne();
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
            re[i].SetActive(true);
        }
        //스프라이트 받아옴
        //랜덤숫자들->얘랑 누른거랑 비교하기.

        //Debug.Log("랜덤 수 생성" + randoms[0] + "and" + randoms[1]);
        success = false;
        //Debug.Log("num : " + lvNum);
    }

    public IEnumerator RiceDown(GameObject obj, float target)
    {
        float duration = 0.4f;
        float currentTime = 0.0f;
        float currentTime2 = 0.0f;
        float objY = obj.GetComponent<Transform>().position.y + target;
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
                if (chk == true) StartCoroutine(RiceDown(Bigri[a], 4));
                break;
        }
    }
}
