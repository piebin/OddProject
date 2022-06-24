using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class Album : MonoBehaviour

{
    //������, ������ ���� �ѹ��� �ܺ� ���Ͽ� �����ؾ��ҵ�.
    public  GameObject[] locks = new GameObject[9];
    string achieveTh = "Assets/TextFiles/achieve";


    // Start is called before the first frame update
    void Start()
    {
        FileStream achieveR = new FileStream(achieveTh, FileMode.Open);
        StreamReader achieveReader = new StreamReader(achieveR);
        string achieveLine = null;

        while ((achieveLine = achieveReader.ReadLine()) != null)
        {

            if (achieveLine == "1")
            {
                Open(0);
            }
        }

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
