using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class Album : MonoBehaviour

{
    //수집도, 오픈한 업적 넘버는 외부 파일에 저장해야할듯.
    public  GameObject[] locks = new GameObject[10];
    public GameObject achieveName;
    public Sprite[] acNames;


    // Start is called before the first frame update
    void Start()
    {

            if (PlayerPrefs.GetInt("achieve_key0") == 1)
            {
                Open(0);
                achieveName.GetComponent<AlbumTextCh>().acNames[0] = acNames[0];
            }
            if (PlayerPrefs.GetInt("achieve_key1") == 1)
            {
                Open(1);
                achieveName.GetComponent<AlbumTextCh>().acNames[1] = acNames[1];
            }
            if (PlayerPrefs.GetInt("achieve_key2") == 1)
            {
                Open(2);
                achieveName.GetComponent<AlbumTextCh>().acNames[2] = acNames[2];
            }
            if (PlayerPrefs.GetInt("achieve_key3") == 1)
            {
                Open(3);
                achieveName.GetComponent<AlbumTextCh>().acNames[3] = acNames[3];
            }
            if (PlayerPrefs.GetInt("achieve_key4") == 1)
            {
                Open(4);
                achieveName.GetComponent<AlbumTextCh>().acNames[4] = acNames[4];
            }
            if (PlayerPrefs.GetInt("achieve_key5") == 1)
            {
                Open(5);
                achieveName.GetComponent<AlbumTextCh>().acNames[5] = acNames[5];
            }
            if (PlayerPrefs.GetInt("achieve_key6") == 1)
            {
                Open(6);
                achieveName.GetComponent<AlbumTextCh>().acNames[6] = acNames[6];
            }
            if (PlayerPrefs.GetInt("achieve_key7") == 1)
            {
                Open(7);
                achieveName.GetComponent<AlbumTextCh>().acNames[7] = acNames[7];
            }
            if (PlayerPrefs.GetInt("achieve_key8") == 1)
            {
                Open(8);
                achieveName.GetComponent<AlbumTextCh>().acNames[8] = acNames[8];
            }

            if (PlayerPrefs.GetInt("achieve_key9") == 1)
            {
                Open(9);
                achieveName.GetComponent<AlbumTextCh>().acNames[9] = acNames[9];
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
