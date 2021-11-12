using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuestTimer : MonoBehaviour

{
    Animator anim; 

    private void ChangeColor()
    {

    }

    private void GuestOver()
    {
        GameManager gm = GameObject.Find("GameObject").GetComponent<GameManager>();
        gm.ChangeGuest();
    }

    public void GuestOn()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("GuestOn", true);
        Debug.Log("timer on");
    }

    public void GuestOff()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("GuestOn", false);
        Debug.Log("timer off");
    }
}
