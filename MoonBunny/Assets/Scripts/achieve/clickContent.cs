using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class clickContent : MonoBehaviour
{
    public GameObject scrollbar, nameT, contentT, BackGround, showImg, clickText, back;
    private bool touchChk = false;
    private Sprite clickImg, bgReal;
    public Sprite bgChange;
    private GraphicRaycaster gr;
    private List<RaycastResult> results;
    private PointerEventData downPed = new PointerEventData(null);
    public AudioSource[] audioSource;
    public GameObject rightB;
    public GameObject leftB;

    // Start is called before the first frame update
    void Start()
    {
        clickText.SetActive(false);
        gr = GetComponent<GraphicRaycaster>();
        bgReal = BackGround.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
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
        }
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
                if (results[0].gameObject.tag == "content" && results[0].gameObject.GetComponent<Image>().sprite.name != "rock")
                {
                    if(!touchChk)
                        audioSource[0].Play();
                    else
                        audioSource[1].Play();
                    touchChk = !touchChk;
                }
            }
            //results[0].gameObject.transform.position = ped.position;
        }

        if (touchChk)
        {
            scrollbar.gameObject.SetActive(false);
            nameT.SetActive(false);
            contentT.SetActive(false);
            back.SetActive(false);
            showImg.SetActive(true);
            clickText.SetActive(true);
            leftB.SetActive(false);
            rightB.SetActive(false);
            BackGround.GetComponent<SpriteRenderer>().sprite = bgChange;
            try { clickImg = results[0].gameObject.GetComponent<Image>().sprite; }
            catch { }
            showImg.gameObject.GetComponent<Image>().sprite = clickImg;
        }

        if (!touchChk)
        {
            scrollbar.gameObject.SetActive(true);
            nameT.SetActive(true);
            contentT.SetActive(true);
            back.SetActive(true);
            BackGround.GetComponent<SpriteRenderer>().sprite = bgReal;
            showImg.gameObject.GetComponent<Image>().sprite = null;
            showImg.SetActive(false);
            clickText.SetActive(false);
            leftB.SetActive(true);
            rightB.SetActive(true);
            try
            {
                results[0].gameObject.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f);
            }
            catch { }
        }
    }
}
