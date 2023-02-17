using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class clickContent : MonoBehaviour
{
    public GameObject scrollbar, nameT, contentT, BackGround, showImg, back;
    private bool touchChk = false;
    private Sprite clickImg, bgReal;
    public Sprite bgChange;
    private GraphicRaycaster gr;
    private List<RaycastResult> results;
    private PointerEventData downPed = new PointerEventData(null);
    public AudioSource[] audioSource;
    public GameObject rightB;
    public GameObject leftB;

    public GameObject textob;

    public GameObject down;
    public GameObject ClickT;


    // Start is called before the first frame update
    void Start()
    {
        
        gr = GetComponent<GraphicRaycaster>();
        bgReal = BackGround.GetComponent<SpriteRenderer>().sprite;
    }


    public void clickCon()
    {
        touchChk = !touchChk;
    }

    public void clickT()
    {
        touchChk = !touchChk;
    }



    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonUp(0))
        {
            Vector3 p = Input.mousePosition;
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(cast, out hit))
            {
                Debug.Log(hit.collider.gameObject);
                if (hit.collider.gameObject.tag == "content")
                {
                    touchChk = !touchChk;
                    //hit.collider.gameObject.GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f);
                }
            }
        }*/
        if(Input.GetMouseButtonDown(0))
        {
            downPed = new PointerEventData(null);
            downPed.position = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            var ped = new PointerEventData(null);
            ped.position = Input.mousePosition;
            results = new List<RaycastResult>();
            gr.Raycast(ped, results);


            if (results.Count <= 0) return;
            if (downPed.position == ped.position) {

                //Debug.Log(results[0].gameObject.name);

                /*if(results[0].gameObject == clickText)
                {
                    touchChk = !touchChk;
                }*/

                if (results[0].gameObject.tag == "content" && results[0].gameObject.GetComponent<Image>().sprite.name != "ÁÂ¹°¼è ÀÏ·¯½ºÆ® Ä«µå")
                {

                    //Debug.Log(results[0].gameObject.GetComponent<Image>().sprite.name);

                    if (!touchChk)
                    {
                        audioSource[0].Play();
                        
                    }
                        
                    else
                    {
                        audioSource[1].Play();
                    }
                     
                    //touchChk = !touchChk;

                   
                    if(textob.GetComponent<AlbumTextCh>().position!=0)
                    {    
                        leftB.SetActive(true);
                    }

                    if (textob.GetComponent<AlbumTextCh>().position != -2250)
                    {
                        rightB.SetActive(true);
                        
                    }


                }
            }
            //results[0].gameObject.transform.position = ped.position;
        }

        if (touchChk)
        {

            down.SetActive(true);
            ClickT.SetActive(true);

            leftB.SetActive(false);
            rightB.SetActive(false);

            scrollbar.gameObject.SetActive(false);
            nameT.SetActive(false);
            contentT.SetActive(false);
            back.SetActive(false);
            showImg.SetActive(true);

            BackGround.GetComponent<SpriteRenderer>().sprite = bgChange;
            try { clickImg = results[0].gameObject.GetComponent<Image>().sprite; }
            catch { }
            showImg.gameObject.GetComponent<Image>().sprite = clickImg;
        }

        if (!touchChk)
        {
            down.SetActive(false);
            ClickT.SetActive(false);

            scrollbar.gameObject.SetActive(true);
            nameT.SetActive(true);
            contentT.SetActive(true);
            back.SetActive(true);
            BackGround.GetComponent<SpriteRenderer>().sprite = bgReal;
            showImg.gameObject.GetComponent<Image>().sprite = null;
            showImg.SetActive(false);

            leftB.SetActive(true);
            rightB.SetActive(true);

            GameObject.Find("Text").GetComponent<AlbumTextCh>().checkArrow();

            try
            {
                results[0].gameObject.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f);
            }
            catch { }
        }
    }
}
