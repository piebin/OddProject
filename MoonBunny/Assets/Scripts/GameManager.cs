using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject character;
    public int[] randoms = new int[2];
    public Sprite[] sprites = new Sprite[4];
    public GameObject re1;
    public GameObject re2;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer ren1 = re1.GetComponent<SpriteRenderer>();
        SpriteRenderer ren2 = re2.GetComponent<SpriteRenderer>();
        Invoke("guest", 5);
        randoms[0] = Random.Range(0, 3);
        randoms[1] = Random.Range(0, 3);
        Debug.Log("·£´ý ¼ö »ý¼º" + randoms[0] + "and" + randoms[1]);
        ren1.sprite = sprites[randoms[0]];
        ren2.sprite = sprites[randoms[1]];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void guest()
    {
        character.SetActive(true);
    }
}
