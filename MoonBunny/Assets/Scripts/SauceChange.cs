using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceChange : MonoBehaviour
{
    public GameObject[] buttons = new GameObject[8];
    public GameObject Sbutton;
    public Sprite sauceB;
    public Sprite ddukB;

    private void Start()
    {
        Debug.Log("start ");

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.start)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject==Sbutton)
            {
                //Debug.Log("clicked");
                if (buttons[0].activeSelf == true)
                {
                    Sbutton.GetComponent<SpriteRenderer>().sprite = ddukB;

                    for (int i = 0; i < 4; i++)
                    {
                        buttons[i].SetActive(false);
                        //Debug.Log("DeActivate Rice");

                    }//떡 버튼 비활성화
                    for (int i = 4; i < 8; i++)
                    {
                        buttons[i].SetActive(true);
                        //Debug.Log("Activate Sauce");
                    }//소스 버튼 활성화
                }
                else if (buttons[4].activeSelf == true)
                {
                    Sbutton.GetComponent<SpriteRenderer>().sprite = sauceB;

                    for (int i = 0; i < 4; i++)
                    {
                        buttons[i].SetActive(true);
                        //Debug.Log("Activate Rice");
                    }//떡 버튼 활성화
                    for (int i = 4; i < 8; i++)
                    {
                        buttons[i].SetActive(false);
                        //Debug.Log("DeActivate Suace");
                    }//소스 버튼 비활성화
                }
            }

        }
    }
}
