using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject character;
    public int[] randoms = new int[2];
    public int[] mynums = new int[2];
    public Sprite[] sprites = new Sprite[4];
    public GameObject[] buttons = new GameObject[4];
    public GameObject Bigri1;
    public GameObject Bigri2;
    public GameObject re1;
    public GameObject re2;
    int num;

    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("guest", 5);
        Invoke("randomRice", 5);
        //InvokeRepeating("randomRice", 5, 10);//잘 작동되는지 테스트용
        num = 0;
    }

        
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {

                if (hit.collider.gameObject == buttons[0])
                {
                    mynums[num] = 0;
                    Bigrice(num, mynums[num]);
                }
                else if (hit.collider.gameObject == buttons[1])
                {
                    mynums[num] = 1;
                    Bigrice(num, mynums[num]);
                }
                else if (hit.collider.gameObject == buttons[2])
                {
                    mynums[num] = 2;
                    Bigrice(num, mynums[num]);
                }
                else if (hit.collider.gameObject == buttons[3])
                {
                    mynums[num] = 3;
                    Bigrice(num, mynums[num]);
                }
                num++;
                if (num >= 2)
                {
                    num = 0;
                    
                }

            }

        }
    }

    private void guest()
    {
        character.SetActive(true);
    }

    private void randomRice()
    {
        SpriteRenderer ren1 = re1.GetComponent<SpriteRenderer>();
        SpriteRenderer ren2 = re2.GetComponent<SpriteRenderer>();
        //스프라이트 받아옴
        randoms[0] = Random.Range(0, 3);
        randoms[1] = Random.Range(0, 3);
        //Debug.Log("랜덤 수 생성" + randoms[0] + "and" + randoms[1]);
        ren1.sprite = sprites[randoms[0]];
        ren2.sprite = sprites[randoms[1]];
    }

    private void Bigrice(int a, int b)
    {
        SpriteRenderer big0 = Bigri1.GetComponent<SpriteRenderer>();
        SpriteRenderer big1 = Bigri2.GetComponent<SpriteRenderer>();

        if (a == 0)
            big0.sprite = sprites[b];
        else
            big1.sprite = sprites[b];


    }
}
