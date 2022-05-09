using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Album : MonoBehaviour

{

    //수집도, 오픈한 업적 넘버는 외부 파일에 저장해야할듯.

    public  GameObject[] locks = new GameObject[9];

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("achieve");

        Open(0);
        Debug.Log("open");
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
