using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumTextCh : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public GameObject card5;
    public GameObject card6;
    public GameObject card7;
    public GameObject card8;
    public GameObject card9;

    public AudioSource[] audioSource;
    private bool[] chkCenter = new bool[10];
    private Text coordinate;
    private string coor_format = "({0}, {1})";

    public Text nameT;
    public Text contentT;
    private string[] nameA = new string[9] { "두둥, 첫 개시!", "이러다 짤리겠어!", "오늘도 부지런히", "앗, 내 정신 좀 봐", "베테랑 꼬치꾼", "그대는 어느별에서?", "참 멋진 패션이네요!", "묘하게 열받는 표정", "이런 걸 왜 실패하냐?" };//업적 이름 표시
    private string[] contentA = new string[9] { "가게 첫 오픈 시 달성", "잃은 하트 20개 돌파 시 달성", "당근 150,000개 소지 시 달성", "떡을 끼우지 않고 소스 먼저 칠할 때 달성", "12레벨 돌파 시 달성", "모든 케릭터 우주복 구경 시 달성", "모든 캐릭터 일상복A 구경 시 달성", "고슴도치 모든 복장 구경 시 달성", "Lv 1~3 도중 실패 시 달성" };//업적 내용 표시

    private float X;
    private float Y;

    public float position = 0f;
    public float now = 0f;

    public ScrollRect sr;

    public void RightB()
    {
        position -= 200f;
        sr.content.localPosition = new Vector3(position, -0.9f, 0);


    }

    public void LeftB()
    {
        position += 200f;
        sr.content.localPosition = new Vector3(position, -0.9f, 0);
    }



    public void SetX(Scrollbar sb)
    {
        RectTransform card2r = card2.GetComponent<RectTransform>();
        RectTransform card3r = card3.GetComponent<RectTransform>();
        RectTransform card4r = card4.GetComponent<RectTransform>();
        RectTransform card5r = card5.GetComponent<RectTransform>();
        RectTransform card6r = card6.GetComponent<RectTransform>();
        RectTransform card7r = card7.GetComponent<RectTransform>();
        RectTransform card8r = card8.GetComponent<RectTransform>();
        RectTransform card9r = card9.GetComponent<RectTransform>();
        RectTransform card1r = card1.GetComponent<RectTransform>();


        X = sb.value;

        if(X<0.07)
        {
            if (chkCenter[1] == false)
            {
                resetArray();
                chkCenter[1] = true;
                audioSource[1].Play();
                Vibration.Vibrate((long)100);
            }
            nameT.text = nameA[0];
            contentT.text = contentA[0];

            card1r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//2번 사이즈 감소
            card2r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//2번 사이즈 감소


        }//1번
        


        else if(X>=0.07 && X<0.19)
        {
            if (chkCenter[2] == false)
            {
                resetArray();
                chkCenter[2] = true;
                audioSource[2].Play();
                Vibration.Vibrate((long)100);
            }
            nameT.text = nameA[1];
            contentT.text = contentA[1];

            card2r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//2번 사이즈 증가
            card3r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//1번 사이즈 감소
            card1r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//3번 사이즈 감소

        }//2번


        else if (X >= 0.19 && X < 0.35)
        {
            if (chkCenter[3] == false)
            {
                resetArray();
                chkCenter[3] = true;
                audioSource[3].Play();
                Vibration.Vibrate((long)100);
            }
            nameT.text = nameA[2];
            contentT.text = contentA[2];

            card3r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//3번 사이즈 증가
            card2r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//2번 사이즈 감소
            card4r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//4번 사이즈 감소


        }//3번

        else if (X >= 0.35 && X < 0.45)
        {
            if (chkCenter[4] == false)
            {
                resetArray();
                chkCenter[4] = true;
                audioSource[4].Play();
                Vibration.Vibrate((long)100);
            }
            nameT.text = nameA[3];
            contentT.text = contentA[3];

            card4r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//4번 사이즈 증가
            card3r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//3번 사이즈 감소
            card5r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//5번 사이즈 감소


        }//4번

        else if (X >= 0.45 && X < 0.58)
        {
            if (chkCenter[5] == false)
            {
                resetArray();
                chkCenter[5] = true;
                audioSource[5].Play();
                Vibration.Vibrate((long)100);
            }
            nameT.text = nameA[4];
            contentT.text = contentA[4];

            card5r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//5번 사이즈 증가
            card4r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//4번 사이즈 감소
            card6r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//6번 사이즈 감소


        }//5번

        else if (X >= 0.58 && X < 0.71)
        {
            if (chkCenter[6] == false)
            {
                resetArray();
                chkCenter[6] = true;
                audioSource[6].Play();
                Vibration.Vibrate((long)100);
            }
            nameT.text = nameA[5];
            contentT.text = contentA[5];

            card6r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//6번 사이즈 증가
            card5r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//5번 사이즈 감소
            card7r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//7번 사이즈 감소


        }//6번

        else if (X >= 0.71 && X < 0.86)
        {
            if (chkCenter[7] == false)
            {
                resetArray();
                chkCenter[7] = true;
                audioSource[7].Play();
                Vibration.Vibrate((long)100);
            }
            nameT.text = nameA[6];
            contentT.text = contentA[6];

            card7r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//7번 사이즈 증가
            card8r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//8번 사이즈 감소
            card6r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//6번 사이즈 감소


        }//7번

        else if (X >= 0.86 && X < 0.97)
        {
            if (chkCenter[8] == false)
            {
                resetArray();
                chkCenter[8] = true;
                audioSource[8].Play();
                Vibration.Vibrate((long)100);
            }
            nameT.text = nameA[7];
            contentT.text = contentA[7];

            card8r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//8번 사이즈 증가
            card9r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//9번 사이즈 감소
            card7r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//7번 사이즈 감소


        }//8번

        else if (X >= 0.97)
        {
            if (chkCenter[9] == false)
            {
                resetArray();
                chkCenter[9] = true;
                audioSource[9].Play();
                Vibration.Vibrate((long)100);
            }
            nameT.text = nameA[8];
            contentT.text = contentA[8];

            card9r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//9번 사이즈 증가
            card8r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//8번 사이즈 감소

        }//9번
            
        //coordinate.text = string.Format(coor_format, X.ToString(),Y.ToString());
    }



    public void SetY(Scrollbar sb)
    {
        Y = sb.value;
        //coordinate.text = string.Format(coor_format, X.ToString(), Y.ToString());
    }

    public void resetArray()
    {
        for(int i=1; i< chkCenter.Length; i++)
        {
            chkCenter[i] = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        resetArray();
        coordinate = GetComponent<Text>();
        //sr.content.localPosition = new Vector3(0f, -0.9f, 0);
    }

    private void Update()
    {
        //Debug.Log("position : " + sr.content.localPosition);
    }


}
