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

    private AudioSource audioSource;
    private Text coordinate;
    private string coor_format = "({0}, {1})";

    public Text nameT;
    public Text contentT;
    private string[] nameA = new string[9] { "�ε�, ù ����!", "�̷��� ©���ھ�!", "���õ� ��������", "��, �� ���� �� ��", "���׶� ��ġ��", "�״�� ���������?", "�� ���� �м��̳׿�!", "���ϰ� ���޴� ǥ��", "�̷� �� �� �����ϳ�?" };//���� �̸� ǥ��
    private string[] contentA = new string[9] { "���� ù ���� �� �޼�", "���� ��Ʈ 20�� ���� �� �޼�", "��� 150,000�� ���� �� �޼�", "���� ������ �ʰ� �ҽ� ���� ĥ�� �� �޼�", "12���� ���� �� �޼�", "��� �ɸ��� ���ֺ� ���� �� �޼�", "��� ĳ���� �ϻ�A ���� �� �޼�", "����ġ ��� ���� ���� �� �޼�", "Lv 1~3 ���� ���� �� �޼�" };//���� ���� ǥ��

    private float X;
    private float Y;

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
            nameT.text = nameA[0];
            contentT.text = contentA[0];

            card1r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//2�� ������ ����

            card2r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//2�� ������ ����


        }//1��
        


        else if(X>=0.07 && X<0.19)
        {
            nameT.text = nameA[1];
            contentT.text = contentA[1];

            card2r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//2�� ������ ����
            card3r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//1�� ������ ����
            card1r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//3�� ������ ����

        }//2��


        else if (X >= 0.19 && X < 0.35)
        {
            nameT.text = nameA[2];
            contentT.text = contentA[2];

            card3r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//3�� ������ ����
            card2r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//2�� ������ ����
            card4r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//4�� ������ ����


        }//3��

        else if (X >= 0.35 && X < 0.45)
        {
            nameT.text = nameA[3];
            contentT.text = contentA[3];

            card4r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//4�� ������ ����
            card3r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//3�� ������ ����
            card5r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//5�� ������ ����


        }//4��

        else if (X >= 0.45 && X < 0.58)
        {
            audioSource.Play();
            nameT.text = nameA[4];
            contentT.text = contentA[4];

            card5r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//5�� ������ ����
            card4r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//4�� ������ ����
            card6r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//6�� ������ ����


        }//5��

        else if (X >= 0.58 && X < 0.71)
        {
            nameT.text = nameA[5];
            contentT.text = contentA[5];

            card6r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//6�� ������ ����
            card5r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//5�� ������ ����
            card7r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//7�� ������ ����


        }//6��

        else if (X >= 0.71 && X < 0.86)
        {
            nameT.text = nameA[6];
            contentT.text = contentA[6];

            card7r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//7�� ������ ����
            card8r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//8�� ������ ����
            card6r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//6�� ������ ����


        }//7��

        else if (X >= 0.86 && X < 0.97)
        {
            nameT.text = nameA[7];
            contentT.text = contentA[7];

            card8r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//8�� ������ ����
            card9r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//9�� ������ ����
            card7r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//7�� ������ ����


        }//8��

        else if (X >= 0.97)
        {
            nameT.text = nameA[8];
            contentT.text = contentA[8];

            card9r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 270);//9�� ������ ����
            card8r.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);//8�� ������ ����



        }//9��
            
        //coordinate.text = string.Format(coor_format, X.ToString(),Y.ToString());
    }






    public void SetY(Scrollbar sb)
    {
        Y = sb.value;
        //coordinate.text = string.Format(coor_format, X.ToString(), Y.ToString());
    }


    // Start is called before the first frame update
    void Start()
    {
        coordinate = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }


}
