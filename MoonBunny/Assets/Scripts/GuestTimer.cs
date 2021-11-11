using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuestTimer : MonoBehaviour

{

    private void ChangeColor()
    {

    }

    private void GuestOver()
    {
        GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();
        gm.ChangeGuest();
    }
}
