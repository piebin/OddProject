using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Animator timerAnim;
    private GameObject timeOver;
    private int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        timerAnim = GetComponent<Animator>();
        timeOver = GameObject.Find("GameOver");
        timeOver.SetActive(false);
    }

    void gameOver()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (timerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
            num++;
        }

        if(num == 1)
        {
            Debug.Log("Game Over");
            timeOver.SetActive(true);
            Invoke("gameOver", 2.0f);
        }
    }
}
