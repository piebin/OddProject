using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumTextCh : MonoBehaviour
{

    private Text coordinate;
    private string coor_format = "({0}, {1})";

    public Text nameT;
    public Text contentT;
    public string[] nameA = new string[2] { "두둥, 첫 개시!", "나중에" };//업적 이름 표시
    public string[] contentA = new string[2] { "가게 첫 오픈 시 달성", "나중에" };//업적 내용 표시

    private float X;
    private float Y;

    public void SetX(Scrollbar sb)
    {
        X = sb.value;

        if(X>=0&&X<0.12)
        {
            nameT.text = nameA[0];
            contentT.text = contentA[0];
            coordinate.text = string.Format("n1");
        }


        else if(X>=0.12 && X<0.24)
        {
            nameT.text = nameA[1];
            contentT.text = contentA[1];
            coordinate.text = string.Format("n2");
        }


        else if(X>=0.24 && X<0.36)
        {
            coordinate.text = string.Format("n3");
        }

        else coordinate.text = string.Format(coor_format, X.ToString(),Y.ToString());
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
    }


}
