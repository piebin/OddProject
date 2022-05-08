using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Album : MonoBehaviour

{

    //������, ������ ���� �ѹ��� �ܺ� ���Ͽ� �����ؾ��ҵ�.

    public string[] nameA = new string[2] {"�ε�, ù ����!", "���߿�" };//���� �̸� ǥ��
    public string[] contentA = new string[2] {"���� ù ���� �� �޼�", "���߿�"};//���� ���� ǥ��

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
