using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class Album : MonoBehaviour

{
    //수집도, 오픈한 업적 넘버는 외부 파일에 저장해야할듯.
    public  GameObject[] locks = new GameObject[9];


    // Start is called before the first frame update
    void Start()
    {

            if (PlayerPrefs.GetInt("achieve_key0") == 1)
            {
                Open(0);
            }
            if (PlayerPrefs.GetInt("achieve_key1") == 1)
            {
                Open(1);
            }
            if (PlayerPrefs.GetInt("achieve_key2") == 1)
            {
                Open(2);
            }
            if (PlayerPrefs.GetInt("achieve_key3") == 1)
            {
                Open(3);
            }
            if (PlayerPrefs.GetInt("achieve_key4") == 1)
            {
                Open(4);
            }
            if (PlayerPrefs.GetInt("achieve_key5") == 1)
            {
                Open(5);
            }
            if (PlayerPrefs.GetInt("achieve_key6") == 1)
            {
                Open(6);
            }
            if (PlayerPrefs.GetInt("achieve_key7") == 1)
            {
                Open(7);
            }
            if (PlayerPrefs.GetInt("achieve_key8") == 1)
            {
                Open(8);
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
