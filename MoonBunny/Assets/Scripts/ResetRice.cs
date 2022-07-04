using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRice : MonoBehaviour
{
    private int count = 0;
    private Vector2 mousePos1, mousePos2;
    private Sprite resetMat;
    public GameObject[] sprite = new GameObject[7];
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
        //downAnim.enabled = false;
        StopCoroutine("RiceDown");
    }

    public IEnumerator RiceDown(GameObject obj, float target)
    {
        float duration = 0.3f;
        float currentTime = 0.0f;
        float objY = obj.GetComponent<Transform>().position.y;
        float offset = (target - currentTime) / duration;

        while (currentTime < target)
        {
            currentTime += offset * Time.deltaTime;
            obj.GetComponent<Transform>().position = new Vector3(-3.9f, objY - currentTime, 0);
            yield return null;
        }
        obj.SetActive(false);
        obj.GetComponent<Transform>().position = new Vector3(-3.9f, objY, 0);
        yield break;
    }

    // Start is called before the first frame update
    void Start()
    {
        resetMat = sprite[0].GetComponent<SpriteRenderer>().sprite;
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
            mousePos2 = Camera.ScreenToWorldPoint(mousePos2);
        }

        if(mousePos1.y > mousePos2.y && count == 0)
        {
            if (mousePos1.x > -6 && mousePos1.x < -3 && mousePos2.x > -6 && mousePos2.x < -3)
            {
                //sprite1.GetComponent<SpriteRenderer>().sprite = resetMat;
                //sprite2.GetComponent<SpriteRenderer>().sprite = resetMat;
                for (int i=0; i<sprite.Length; i++)
                {
                    //sprite[i].SetActive(false);
                    StartCoroutine(RiceDown(sprite[i], 20));
                }
                GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();
                gm.num = 0;
                gm.snum = 0;

                downAnim.enabled = true;
                GetComponent<AudioSource>().Play();
                downAnim.Play("Down", -1, 0f);
                Invoke("stopAnimation", 0.4f);
            }
            mousePos1.y = 0;
            mousePos2.y = 0;
        }
    }
}
