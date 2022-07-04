using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    public GameObject gm, timer, circle, level, life, open;
    // Start is called before the first frame update
    void Start()
    {
        gm.SetActive(false);
        timer.SetActive(false);
        circle.SetActive(false);
        level.SetActive(false);
        life.SetActive(false);
    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gm.GetComponent<GameManager>().goBack)
                {
                    gm.GetComponent<GameManager>().titlePanel.SetActive(true);
                    gm.GetComponent<GameManager>().goBack.GetComponent<AudioSource>().Play();
                }
            }
        }
    }

    public void openBtn()
    {
        gm.SetActive(true);
        timer.SetActive(true);
        circle.SetActive(true);
        level.SetActive(true);
        life.SetActive(true);
        open.SetActive(false);
    }

    // Update is called once per frame

}
