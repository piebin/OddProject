using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GuestTimer : MonoBehaviour

{
    Animator anim;
    public int num = 0;
    public GameObject[] life = new GameObject[3];
    public Sprite emptyLife;
    public GameObject timeOver;

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

        if (num == 3)
        {
            Debug.Log("Game Over");
            timeOver.SetActive(true);
            Invoke("gameOver", 2.0f);
        }

        //Debug.Log("timer on");
    }

    public void GuestOff()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("GuestOn", false);

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            life[num].GetComponent<SpriteRenderer>().sprite = emptyLife;
            num++;
        }

        //Debug.Log("timer off");
    }

    void gameOver()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
