using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Album : MonoBehaviour

{

    //수집도, 오픈한 업적 넘버는 외부 파일에 저장해야할듯.

    public string[] nameA = new string[2] {"두둥, 첫 개시!", "나중에" };//업적 이름 표시
    public string[] contentA = new string[2] {"가게 첫 오픈 시 달성", "나중에"};//업적 내용 표시

    public GameObject[] locks = new GameObject[9];

    public Text nameUI;
    public Text contentUI;

    // Start is called before the first frame update
    void Start()
    {
        Open(0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public void Open(int n)
    {
        locks[n].GetComponent<LockToImage>().open();
        nameUI.text = nameA[n];
        contentUI.text = contentA[n];
    }

}
