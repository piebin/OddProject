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
    public GameObject t5;


    public Sprite dark1;
    public Sprite dark2;
    public Sprite dark3;
    public Sprite dark4;
    public Sprite dark5;

    private AudioSource audioSource;

    int one = 0;//?ߺ?????


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        one = 0;
        Time.timeScale = 1.0f;
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
            t5.GetComponent<Animation>().Play();
            one++;
        }

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);


        if(hit.collider!=null && Input.GetMouseButton(0))
        {
            if(hit.collider.gameObject == t1)
            {
                audioSource.Play();
                t1.GetComponent<SpriteRenderer>().sprite = dark1;
            }

            if (hit.collider.gameObject == t2)
            {
                audioSource.Play();
                t2.GetComponent<SpriteRenderer>().sprite = dark2;
            }

            if (hit.collider.gameObject == t3)
            {
                audioSource.Play();
                t3.GetComponent<SpriteRenderer>().sprite = dark3;
            }

            if (hit.collider.gameObject == t4)
            {
                audioSource.Play();
                t4.GetComponent<SpriteRenderer>().sprite = dark4;
            }

            if (hit.collider.gameObject == t5)
            {
                audioSource.Play();
                t5.GetComponent<SpriteRenderer>().sprite = dark5;
            }
        }


        if (hit.collider!=null && Input.GetMouseButtonDown(0))
        {

            if(hit.collider.gameObject == t1)
            {
                Invoke("GameStart", 0.5f);
            }

            if (hit.collider.gameObject == t2)
            {
                Invoke("Album", 0.5f);
            }

            if (hit.collider.gameObject == t3)
            {
                Invoke("Shop", 0.5f);
            }

            if (hit.collider.gameObject == t4)
            {
                Invoke("Option", 0.5f);
            }

            if (hit.collider.gameObject == t5)
            {
                Invoke("GameQuit", 0.5f);
            }
        }
    }

    public void GameStart()
    {
        //Debug.Log("?????? Ŭ????");
        SceneManager.LoadScene("SampleScene");
    }

    public void Album()
    {
        //Debug.Log("?ٹ??? Ŭ????");
        SceneManager.LoadScene("Achieve(real)");
    }

    public void Shop()
    {
        //Debug.Log("?????? Ŭ????");
        SceneManager.LoadScene("Shop(real)");
    }

    public void Option()
    {
        //Debug.Log("?ɼ??? Ŭ????");
        PlayerPrefs.DeleteAll();
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        //Debug.Log("???ᰡ Ŭ????");
    }
}
