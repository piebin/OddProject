using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleClick : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;

    int one = 0;//�ߺ�����


    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && one == 0)
        {
            t1.GetComponent<Animation>().Play();
            t2.GetComponent<Animation>().Play();
            t3.GetComponent<Animation>().Play();
            t4.GetComponent<Animation>().Play();

            one++;

        }

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        if (hit.collider!=null && Input.GetMouseButtonDown(0))
        {
            if(hit.collider.gameObject == t1)
            {
                Debug.Log("������ Ŭ����");
                SceneManager.LoadScene("SampleScene");
            }

            if (hit.collider.gameObject == t2)
            {
                Debug.Log("�ٹ��� Ŭ����");
                SceneManager.LoadScene("Achieve(real)");
            }

            if (hit.collider.gameObject == t3)
            {
                Debug.Log("������ Ŭ����");
                SceneManager.LoadScene("Shop(real)");
            }

            if (hit.collider.gameObject == t4)
            {
                Debug.Log("�ɼ��� Ŭ����");
            }
        }

    }
}
