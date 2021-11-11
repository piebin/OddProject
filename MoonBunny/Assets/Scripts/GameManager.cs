using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] character = new GameObject[3];
    private int[] randoms = new int[2];
    private int[] mynums = new int[2];
    private int[] clickedB = new int[2];
    public Sprite[] sprites = new Sprite[4];
    public GameObject[] buttons = new GameObject[4];
    public GameObject Bigri1;
    public GameObject Bigri2;
    public GameObject re1;
    public GameObject re2;
    public int num;
    public GameObject menu, menuIcon;
    private int CharacterNum;



    // Start is called before the first frame update
    void Start()
    {
        Invoke("guest", 1);
        Invoke("randomRice", 1);
        num = 0;
        menuIcon.SetActive(true);
        menu.SetActive(false);
    }

        
    // Update is called once per frame
    void Update()
    {
        //��ư �����°�
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == menuIcon)
                {
                    menuIcon.SetActive(false);
                    menu.SetActive(true);
                    num--;
                }

                if (hit.collider.gameObject == buttons[0])
                {
                    mynums[num] = 0;
                    clickedB[num] = mynums[num]; //Ŭ���Ѱ� ���� �����ص�.
                    Bigrice(num, mynums[num]); 
                }
                else if (hit.collider.gameObject == buttons[1])
                {
                    mynums[num] = 1;
                    clickedB[num] = mynums[num];
                    Bigrice(num, mynums[num]);
                }
                else if (hit.collider.gameObject == buttons[2])
                {
                    mynums[num] = 2;
                    clickedB[num] = mynums[num];
                    Bigrice(num, mynums[num]);
                }
                else if (hit.collider.gameObject == buttons[3])
                {
                    mynums[num] = 3;
                    clickedB[num] = mynums[num];
                    Bigrice(num, mynums[num]);
                }
                num++;
                
                //Ŭ���ѰŶ� �������� ���ؼ� ������ Ȯ��
                if (num >= 2)
                {
                    if (clickedB[0] == randoms[0] && clickedB[1] == randoms[1])
                    {
                        Debug.Log("congraturation");
                        ChangeGuest();
                    }

                    num = 0;
                }
            }
        }
    }

    public void AnActive()
    {
        for(int i=0; i<3; i++)
        {
            if (character[i].activeSelf)
                character[i].SetActive(false);
        } //���� ĳ������ Ȱ��ȭ�Ȱ͸� ã�Ƽ� ��Ȱ��ȭ��Ŵ

        Bigri1.SetActive(false);
        Bigri2.SetActive(false);
        re1.SetActive(false);
        re2.SetActive(false);
    }

    public void ChangeGuest()
    {
        Invoke("AnActive", 1);
        Invoke("guest", 1.3f);
        Invoke("randomRice", 1.3f);
    }

    public void guest()
    {
        CharacterNum = Random.Range(0, 3); //�Լ��� ����ɶ����� ���� �� �ʱ�ȭ
        Debug.Log("gueset number : " + CharacterNum);
        character[CharacterNum].SetActive(true); //���� Ȱ��ȭ
    }

    public void randomRice()
    {
        SpriteRenderer ren1 = re1.GetComponent<SpriteRenderer>();
        SpriteRenderer ren2 = re2.GetComponent<SpriteRenderer>();
        //��������Ʈ �޾ƿ�

        randoms[0] = Random.Range(0, 3);
        randoms[1] = Random.Range(0, 3);
        //�������ڵ�->��� �����Ŷ� ���ϱ�.

        Debug.Log("���� �� ����" + randoms[0] + "and" + randoms[1]);

        ren1.sprite = sprites[randoms[0]];
        re1.SetActive(true);

        ren2.sprite = sprites[randoms[1]];
        re2.SetActive(true);

    }

    private void Bigrice(int a, int b)
    {
        SpriteRenderer big0 = Bigri1.GetComponent<SpriteRenderer>();
        SpriteRenderer big1 = Bigri2.GetComponent<SpriteRenderer>();

        if (a == 0)
        {
            big0.sprite = sprites[b];
            Bigri1.SetActive(true);
        } //1��° ���϶� 1��°���� ������ư�� ��������Ʈ�� ����

        else
        {
            big1.sprite = sprites[b];
            Bigri2.SetActive(true);
        }



    }
}
