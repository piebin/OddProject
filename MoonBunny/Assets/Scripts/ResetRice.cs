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
        downAnim.enabled = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePos1 = Input.mousePosition;
            count++;
        }

        if (Input.GetMouseButtonUp(0))
        {
            count = 0;
            mousePos2 = Input.mousePosition;
        }

        if(mousePos1.y > mousePos2.y && count == 0)
        {
            if (mousePos1.x > 380 && mousePos1.x < 450 && mousePos2.x > 380 && mousePos2.x < 450)
            {
                //sprite1.GetComponent<SpriteRenderer>().sprite = resetMat;
                //sprite2.GetComponent<SpriteRenderer>().sprite = resetMat;
                sprite1.SetActive(false);
                sprite2.SetActive(false);
                downAnim.enabled = true;
                Invoke("stopAnimation", 0.5f);
            }
            mousePos1.y = 0;
            mousePos2.y = 0;
        }
    }
}
