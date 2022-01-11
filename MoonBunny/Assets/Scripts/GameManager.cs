using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] character = new GameObject[3];
    private int[] randoms = new int[2];
    private int[] mynums = new int[2];
    private int[] ClickedB = new int[2];
    private int[] clickedS = new int[2];
    public Sprite[] sprites = new Sprite[20];
    public GameObject[] buttons = new GameObject[4];
    public GameObject[] saucesB = new GameObject[4];
    public GameObject Bigri1;
    public GameObject Bigri2;
    public GameObject re1;
    public GameObject re2;
    public int num;
    public int snum;
    public int sauceN;
    public GameObject menu, menuIcon;
    private int CharacterNum;
 


    // Start is called before the first frame update
    void Start()
    {
        Invoke("guest", 1);
        Invoke("randomRice", 1);
        num = 0;
        snum = 0;
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
                    ClickedB[num] = mynums[num]; //Ŭ���Ѱ� ���� �����ص�.
                    Bigrice(num, mynums[num]);
                    num++;
                }
                else if (hit.collider.gameObject == buttons[1])
                {
                    mynums[num] = 1;
                    ClickedB[num] = mynums[num];
                    Bigrice(num, mynums[num]);
                    num++;
                }
                else if (hit.collider.gameObject == buttons[2])
                {
                    mynums[num] = 2;
                    ClickedB[num] = mynums[num];
                    Bigrice(num, mynums[num]);
                    num++;
                }
                else if (hit.collider.gameObject == buttons[3])
                {
                    mynums[num] = 3;
                    ClickedB[num] = mynums[num];
                    Bigrice(num, mynums[num]);
                    num++;
                }

                //�ҽ���ư ������ ��
                //���4��, �� 4��->16�� if
                if(hit.collider.gameObject == saucesB[0]) //�����
                {

                    for (int i=0; i<num; i++)//���ݱ��� ���� ��� Ȯ��
                    {
                        //��� 4�� ��� ������ �ٸ� ��������Ʈ ����
                        if (mynums[snum] == 0)
                        {
                            Bigrice(snum, 4);
                            clickedS[snum] = 4;
                        }

                        if (mynums[snum] == 1)
                        {
                            Bigrice(snum, 8);
                            clickedS[snum] = 8;
                        }

                        if (mynums[snum] == 2)
                        {
                            Bigrice(snum, 12);
                            clickedS[snum] = 12;
                        }

                        if (mynums[snum] == 3)
                        {
                            Bigrice(snum, 16);
                            clickedS[snum] = 16;
                        }

                    }
                    snum++; //�ҽ� ��ư�� ���� Ƚ��
                    
                }

                if (hit.collider.gameObject == saucesB[1]) //������
                {

                    for (int i = 0; i < num; i++)//���ݱ��� ���� ��� Ȯ��
                    {
                        //��� 4�� ��� ������ �ٸ� ��������Ʈ ����
                        if (mynums[snum] == 0)
                        {
                            Bigrice(snum, 5);
                            clickedS[snum] = 5;
                        }

                        if (mynums[snum] == 1)
                        {
                            Bigrice(snum, 9);
                            clickedS[snum] = 9;
                        }

                        if (mynums[snum] == 2)
                        {
                            Bigrice(snum, 13);
                            clickedS[snum] = 13;
                        }

                        if (mynums[snum] == 3)
                        {
                            Bigrice(snum, 17);
                            clickedS[snum] = 17;
                        }

                    }
                    snum++; //�ҽ� ��ư�� ���� Ƚ��

                }

                if (hit.collider.gameObject == saucesB[2]) //�����
                {

                    for (int i = 0; i < num; i++)//���ݱ��� ���� ��� Ȯ��
                    {
                        //��� 4�� ��� ������ �ٸ� ��������Ʈ ����
                        if (mynums[snum] == 0)
                        {
                            Bigrice(snum, 6);
                            clickedS[snum] = 6;
                        }

                        if (mynums[snum] == 1)
                        {
                            Bigrice(snum, 10);
                            clickedS[snum] = 10;
                        }

                        if (mynums[snum] == 2)
                        {
                            Bigrice(snum, 14);
                            clickedS[snum] = 14;
                        }

                        if (mynums[snum] == 3)
                        {
                            Bigrice(snum, 18);
                            clickedS[snum] = 18;
                        }

                    }
                    snum++; //�ҽ� ��ư�� ���� Ƚ��

                }

                if (hit.collider.gameObject == saucesB[3]) //�ʷϻ�
                {

                    for (int i = 0; i < num; i++)//���ݱ��� ���� ��� Ȯ��
                    {
                        //��� 4�� ��� ������ �ٸ� ��������Ʈ ����
                        if (mynums[snum] == 0)
                        {
                            Bigrice(snum, 7);
                            clickedS[snum] = 7;
                        }

                        if (mynums[snum] == 1)
                        {
                            Bigrice(snum, 11);
                            clickedS[snum] = 11;
                        }

                        if (mynums[snum] == 2)
                        {
                            Bigrice(snum, 15);
                            clickedS[snum] = 15;
                        }

                        if (mynums[snum] == 3)
                        {
                            Bigrice(snum, 19);
                            clickedS[snum] = 19;
                        }

                    }
                    snum++; //�ҽ� ��ư�� ���� Ƚ��

                }

                //Ŭ���ѰŶ� �������� ���ؼ� ������ Ȯ��
                if (num >= 2 && snum >= 2)
                {
                    if (clickedS[0] == randoms[0] && clickedS[1] == randoms[1])
                    {
                        Debug.Log("click number : " + clickedS[0] + "," + clickedS[1]);
                        Debug.Log("congraturation");
                        ScoreManager.score += 10;
                        ChangeGuest();
                    }
                    Debug.Log("click number : " + clickedS[0] + "," + clickedS[1]);
                    Debug.Log("num: "+num + "snum: " + snum);
                    num = 0;
                    snum = 0;
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
        GameObject.Find("GuestTime").GetComponent<GuestTimer>().GuestOff();
        //�ִϸ��̼� ��Ȱ��ȭ
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
        character[CharacterNum].SetActive(true); //���� Ȱ��ȭ
        GameObject.Find("GuestTime").GetComponent<GuestTimer>().GuestOn();
        //�ִϸ��̼� Ȱ��ȭ
    }

    public void randomRice()
    {
        SpriteRenderer ren1 = re1.GetComponent<SpriteRenderer>();
        SpriteRenderer ren2 = re2.GetComponent<SpriteRenderer>();
        //��������Ʈ �޾ƿ�

        randoms[0] = Random.Range(4, 19);
        randoms[1] = Random.Range(4, 19);
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
