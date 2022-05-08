using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickMenu : MonoBehaviour
{
    public GameObject menu, menuIcon;
    private Vector2 mousePos;
    Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && menu.activeSelf)
        {
            mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider == null || hit.collider.gameObject.tag == "Untagged")
            {
                menu.SetActive(false);
                menuIcon.SetActive(true);
            }

            else if (hit.collider.gameObject.tag == "Shop")
            {
                SceneManager.LoadScene("Shop(real)");
            }

            else if (hit.collider.gameObject.tag == "Achieve")
            {
                SceneManager.LoadScene("Achieve(real)");
            }

            else if (hit.collider.gameObject.tag == "Setting")
            {
                SceneManager.LoadScene("Setting");
            }
        }

        /*else if (Input.GetMouseButtonDown(0) && !(menu.activeSelf))
        {
            mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            Debug.Log("menu0");

            if (hit.collider.gameObject == menuIcon)
            {
                Debug.Log("menu");
                menuIcon.SetActive(false);
                menu.SetActive(true);
            }
        }*/
    }
}
