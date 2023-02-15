using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gm;
    public GameObject darkBack;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void anim()
    {
        darkBack.SetActive(false);
        gm.GetComponent<GameManager>().goBackNoF();
    }
    public void darkOn()
    {
        darkBack.SetActive(true);
    }


}
