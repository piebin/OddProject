using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class Album : MonoBehaviour

{
    //수집도, 오픈한 업적 넘버는 외부 파일에 저장해야할듯.
    public  GameObject[] locks = new GameObject[9];
    string achieveTh = "Assets/Resources/TextFiles/achieve";//업적 파일 위치


    // Start is called before the first frame update
    void Start()
    {
        FileStream achieveR = new FileStream(achieveTh, FileMode.Open);
        StreamReader achieveReader = new StreamReader(achieveR);
        string achieveLine = null;

        while ((achieveLine = achieveReader.ReadLine()) != null)
        {
            //업적 텍스트 파일을 한줄씩 읽어옴.
            //각 번호에 대한 open함수 실행(이미지 변경->일러스트 공개)

            if (achieveLine == "1")
            {
                Open(0);
            }
            if (achieveLine == "2")
            {
                Open(1);
            }
            if (achieveLine == "3")
            {
                Open(2);
            }
            if (achieveLine == "4")
            {
                Open(3);
            }
            if (achieveLine == "5")
            {
                Open(4);
            }
            if (achieveLine == "6")
            {
                Open(5);
            }
            if (achieveLine == "7")
            {
                Open(6);
            }
            if (achieveLine == "8")
            {
                Open(7);
            }
            if (achieveLine == "9")
            {
                Open(8);
            }
        }

        achieveReader.Close();

    }

    // Update is called once per frame
    void Update()
    {

    }

   public  void Open(int n)
    {
        locks[n].GetComponent<LockToImage>().open();
    }
}
