using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceChange : MonoBehaviour
{
    public GameObject[] buttons = new GameObject[8];

    private void Start()
    {
        Debug.Log("check");
    }

    void OnMouseDown()
    {
        Debug.Log("Buttin clicked");
        if (buttons[0].activeSelf == true)
        {
            Debug.Log("Buttin clicked");
            for(int i=0; i<4; i++)
            {
                buttons[i].SetActive(false);
                Debug.Log("DeActivate Rice");

            }//떡 버튼 비활성화
            for(int i=4; i<8; i++)
            {
                buttons[i].SetActive(true);
                Debug.Log("Activate Sauce");
            }//소스 버튼 활성화
        }
        else if(buttons[4].activeSelf==true)
        {
            for (int i = 0; i < 4; i++)
            {
                buttons[i].SetActive(true);
                Debug.Log("Activate Rice");
            }//떡 버튼 활성화
            for (int i = 4; i < 8; i++)
            {
                buttons[i].SetActive(false);
                Debug.Log("DeActivate Suace");
            }//소스 버튼 비활성화
        }
    }

}
