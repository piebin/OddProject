using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickBg : MonoBehaviour
{
    public GameObject purchasePanel;
    private bool panel;
    // Start is called before the first frame update
    void Start()
    {
        
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
                if (!panel && hit.collider.gameObject.tag == "BG")
                {
                    changeBg.touchChk = !changeBg.touchChk;
                }
            }
        }

        if (purchasePanel.activeSelf)
        {
            panel = true;
        }

        else panel = false;
    }
}
