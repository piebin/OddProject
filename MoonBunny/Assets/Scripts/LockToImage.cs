using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockToImage : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite newimage;
    public Image thisone;

    void Start()
    {
        thisone = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open()
    {
        thisone.sprite = newimage;
        thisone.GetComponent<Button>().interactable = true;
    }
}
