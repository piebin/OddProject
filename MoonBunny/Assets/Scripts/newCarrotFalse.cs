using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCarrotFalse : MonoBehaviour
{
    public GameObject newcarrot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void totalUP()
    {
        newcarrot.SetActive(false);        
        GameObject.Find("score").GetComponent<ScoreCount>().totalUP();
    }

    void whenStart()
    {
        Debug.Log("start");
    }
}
