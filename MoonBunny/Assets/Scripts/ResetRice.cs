using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRice : MonoBehaviour
{
    private int count = 0;
    private Vector2 mousePos1, mousePos2;
    private Sprite resetMat;
    public GameObject[] sprite = new GameObject[7];
    public GameObject BGroup;
    private float BGroupY;
    private float[] spriteY = new float[7];
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
        GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();
        for(int i=0; i<gm.num; i++)
        {
            sprite[i].SetActive(true);
        }
        //downAnim.enabled = false;
        StopCoroutine("RiceDown");
    }

    public IEnumerator RiceDown(GameObject obj, float objY, float target)
    {
        float duration = 0.3f;
        float currentTime = 0.0f;
        float offset = (target - currentTime) / duration;

        while (currentTime < target)
        {
            currentTime += offset * Time.deltaTime;
            obj.GetComponent<Transform>().position = new Vector2(-3.9f, objY - currentTime);
            yield return null;
        }
        obj.SetActive(false);
        obj.GetComponent<Transform>().position = new Vector2(-3.9f, objY + BGroupY);
        yield break;
    }

    // Start is called before the first frame update
    void Start()
    {
        BGroupY = BGroup.transform.position.y;
        resetMat = sprite[0].GetComponent<SpriteRenderer>().sprite;
        downAnim = GetComponent<Animator>();
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        downAnim.enabled = false;

        for(int i=0; i<sprite.Length; i++)
        {
            spriteY[i] = sprite[i].GetComponent<Transform>().position.y;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && GameManager.gamePlay)
        {
            mousePos1 = Input.mousePosition;
            mousePos1 = Camera.ScreenToWorldPoint(mousePos1);
            count = 1;
        }

        if (Input.GetMouseButtonUp(0) && GameManager.gamePlay)
        {
            count = 0;
            mousePos2 = Input.mousePosition;
            mousePos2 = Camera.ScreenToWorldPoint(mousePos2);
        }

        if(mousePos1.y > mousePos2.y + 3 && count == 0)
        {
            if (mousePos1.x > -6 && mousePos1.x < -3 && mousePos2.x > -6 && mousePos2.x < -3)
            {
                BGroupY = BGroup.transform.position.y;
                GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();
                gm.num = 0;
                gm.snum = 0;
                for (int i=0; i<sprite.Length; i++)
                {
                    StartCoroutine(RiceDown(sprite[i], spriteY[i], 20));
                }

                downAnim.enabled = true;
                GetComponent<AudioSource>().Play();
                downAnim.Play("Down", -1, 0f);
                if(PlayerPrefs.GetInt("vibe") == 1) Vibration.Vibrate((long)100);

                Invoke("stopAnimation", 0.4f);
            }
            mousePos1 = new Vector2();
            mousePos2 = new Vector2();
        }
    }
}
