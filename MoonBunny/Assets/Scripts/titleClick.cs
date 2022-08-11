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

    private Sprite bright1;
    private Sprite bright2;
    private Sprite bright3;
    private Sprite bright4;
    private Sprite bright5;

    public Sprite dark1;
    public Sprite dark2;
    public Sprite dark3;
    public Sprite dark4;
    public Sprite dark5;

    public GameObject loadingUp, loadingDown;

    private AudioSource audioSource;
    private bool click = false;

    int one = 0;//중복방지


    void Start()
    {
        bright1 = t1.GetComponent<SpriteRenderer>().sprite;
        bright2 = t2.GetComponent<SpriteRenderer>().sprite;
        bright3 = t3.GetComponent<SpriteRenderer>().sprite;
        bright4 = t4.GetComponent<SpriteRenderer>().sprite;
        bright5 = t5.GetComponent<SpriteRenderer>().sprite;

        loadingDown.SetActive(false);
        loadingUp.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        one = 0;
        Time.timeScale = 1.0f;

        if(PlayerPrefs.GetInt("go_title")==1)
        {
            loadingUp.SetActive(true);
            Invoke("quitLoading", 1.0f);
            PlayerPrefs.SetInt("go_title", 0);
        }
    }

    public void quitLoading()
    {
        loadingUp.SetActive(false);
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
                if(!click) audioSource.Play();
                click = true;
                t1.GetComponent<SpriteRenderer>().sprite = dark1;
            }

            if (hit.collider.gameObject == t2)
            {
                if (!click) audioSource.Play();
                click = true;
                t2.GetComponent<SpriteRenderer>().sprite = dark2;
            }

            if (hit.collider.gameObject == t3)
            {
                if (!click) audioSource.Play();
                click = true;
                t3.GetComponent<SpriteRenderer>().sprite = dark3;
            }

            if (hit.collider.gameObject == t4)
            {
                if (!click) audioSource.Play();
                click = true;
                t4.GetComponent<SpriteRenderer>().sprite = dark4;
            }

            if (hit.collider.gameObject == t5)
            {
                if (!click) audioSource.Play();
                click = true;
                t5.GetComponent<SpriteRenderer>().sprite = dark5;
            }
        }

        try
        {
            if (hit.collider.name == "bg1" && Input.GetMouseButtonUp(0))
            {
                t1.GetComponent<SpriteRenderer>().sprite = bright1;
                t2.GetComponent<SpriteRenderer>().sprite = bright2;
                t3.GetComponent<SpriteRenderer>().sprite = bright3;
                t4.GetComponent<SpriteRenderer>().sprite = bright4;
                t5.GetComponent<SpriteRenderer>().sprite = bright5;
                click = false;
            }
        } catch { }


        if (hit.collider!=null && Input.GetMouseButtonUp(0))
        {
            if(hit.collider.gameObject == t1)
            {
                GameStart();
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

    public void loadSample()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameStart()
    {
        //Debug.Log("시작이 클릭됨");
        loadingDown.GetComponent<Animator>().Rebind();
        loadingDown.GetComponent<Animator>().Update(0f);
        loadingDown.SetActive(true);
        t1.SetActive(false);
        t2.SetActive(false);
        t3.SetActive(false);
        t4.SetActive(false);
        t5.SetActive(false);
        Invoke("loadSample", 1.8f);
    }

    public void Album()
    {
        //Debug.Log("앨범이 클릭됨");
        SceneManager.LoadScene("Achieve(real)");
    }

    public void Shop()
    {
        //Debug.Log("상점이 클릭됨");
        SceneManager.LoadScene("Shop(real)");
    }

    public void Option()
    {
        //Debug.Log("옵션이 클릭됨");
        PlayerPrefs.DeleteAll();
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        //Debug.Log("종료가 클릭됨");
    }
}
