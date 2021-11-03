using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRice : MonoBehaviour
{
    private int count = 0;
    private Vector2 mousePos1, mousePos2;
    private Sprite resetMat;
    public GameObject sprite1, sprite2;
    private Animator downAnim;
    Camera Camera;

    /*void OnMouseDrag()
    {
        if(mousePos1.y > mousePos2.y)
        {
            sprite1.GetComponent<SpriteRenderer>().sprite = resetMat;
            sprite2.GetComponent<SpriteRenderer>().sprite = resetMat;
            Debug.Log("1 : "+mousePos1.y + ", 2 : " + mousePos2.y);
        }
        count++;
    }*/

    public void stopAnimation()
    {
        downAnim.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        resetMat = sprite1.GetComponent<SpriteRenderer>().sprite;
        downAnim = GetComponent<Animator>();
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        downAnim.enabled = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePos1 = Input.mousePosition;
            mousePos1 = Camera.ScreenToWorldPoint(mousePos1);
            count++;
        }

        if (Input.GetMouseButtonUp(0))
        {
            count = 0;
            mousePos2 = Input.mousePosition;
            Debug.Log("1 : " + mousePos2.x);
            mousePos2 = Camera.ScreenToWorldPoint(mousePos2);
            Debug.Log("2 : " + mousePos2.x);
        }

        if(mousePos1.y > mousePos2.y && count == 0)
        {
            if (mousePos1.x > -6 && mousePos1.x < -3 && mousePos2.x > -6 && mousePos2.x < -3)
            {
                //sprite1.GetComponent<SpriteRenderer>().sprite = resetMat;
                //sprite2.GetComponent<SpriteRenderer>().sprite = resetMat;
                Debug.Log("초기화 확인");
                sprite1.SetActive(false);
                sprite2.SetActive(false);
                GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();
                gm.num = 0;

                downAnim.enabled = true;
                Invoke("stopAnimation", 0.5f);
            }
            mousePos1.y = 0;
            mousePos2.y = 0;
        }
    }
}
