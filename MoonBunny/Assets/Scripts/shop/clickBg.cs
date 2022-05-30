using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class clickBg : MonoBehaviour
{
    public GameObject purchasePanel;
    private bool panel;
    private GraphicRaycaster gr;
    private List<RaycastResult> results;
    // Start is called before the first frame update
    void Start()
    {
        gr = GetComponent<GraphicRaycaster>();
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
                if (hit.collider.gameObject.tag == "content")
                {
                    ScrollView.touchChk = !ScrollView.touchChk;
                    //hit.collider.gameObject.GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f);
                }
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            var ped = new PointerEventData(null);
            ped.position = Input.mousePosition;
            results = new List<RaycastResult>();
            gr.Raycast(ped, results);
        
            if (results.Count <= 0) return;
            if (!panel && results[0].gameObject.tag == "content" && results[0].gameObject.GetComponent<Image>().sprite.name != "ÀÚ¹°¼è")
            {
                ScrollView.touchChk = !ScrollView.touchChk;
            }
            //results[0].gameObject.transform.position = ped.position;
        }

        if (purchasePanel.activeSelf)
        {
            panel = true;
        }

        else panel = false;
    }
}
