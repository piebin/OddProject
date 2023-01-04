using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    // Start is called before the first frame update


    public bool deleteData = false;


    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        if (!PlayerPrefs.HasKey("losing_heart"))
        {
            PlayerPrefs.SetInt("losing_heart", 0);
        }


        if (!PlayerPrefs.HasKey("score_key"))
        {
            PlayerPrefs.SetInt("score_key", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key0"))
        {
            PlayerPrefs.SetInt("achieve_key0", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key1"))
        {
            PlayerPrefs.SetInt("achieve_key1", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key2"))
        {
            PlayerPrefs.SetInt("achieve_key2", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key3"))
        {
            PlayerPrefs.SetInt("achieve_key3", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key4"))
        {
            PlayerPrefs.SetInt("achieve_key4", 0);
        }


        if (!PlayerPrefs.HasKey("achieve_key5"))
        {
            PlayerPrefs.SetInt("achieve_key5", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-1"))
        {
            PlayerPrefs.SetInt("achieve_key5-1", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-2"))
        {
            PlayerPrefs.SetInt("achieve_key5-2", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-3"))
        {
            PlayerPrefs.SetInt("achieve_key5-3", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-4"))
        {
            PlayerPrefs.SetInt("achieve_key6-4", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-5"))
        {
            PlayerPrefs.SetInt("achieve_key5-5", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-6"))
        {
            PlayerPrefs.SetInt("achieve_key5-6", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-7"))
        {
            PlayerPrefs.SetInt("achieve_key5-7", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-8"))
        {
            PlayerPrefs.SetInt("achieve_key5-8", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-9"))
        {
            PlayerPrefs.SetInt("achieve_key5-9", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-10"))
        {
            PlayerPrefs.SetInt("achieve_key5-10", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-11"))
        {
            PlayerPrefs.SetInt("achieve_key5-11", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-12"))
        {
            PlayerPrefs.SetInt("achieve_key5-12", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-13"))
        {
            PlayerPrefs.SetInt("achieve_key5-13", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-14"))
        {
            PlayerPrefs.SetInt("achieve_key5-14", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key5-15"))
        {
            PlayerPrefs.SetInt("achieve_key5-15", 0);
        }



        if (!PlayerPrefs.HasKey("achieve_key6"))
        {
            PlayerPrefs.SetInt("achieve_key6", 0);
        }


        if (!PlayerPrefs.HasKey("achieve_key7"))
        {
            PlayerPrefs.SetInt("achieve_key7", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key7-1"))
        {
            PlayerPrefs.SetInt("achieve_key7-1", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key7-2"))
        {
            PlayerPrefs.SetInt("achieve_key7-2", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key7-3"))
        {
            PlayerPrefs.SetInt("achieve_key7-3", 0);
        }




        if (!PlayerPrefs.HasKey("achieve_key8"))
        {
            PlayerPrefs.SetInt("achieve_key8", 0);
        }

        if (!PlayerPrefs.HasKey("achieve_key9"))
        {
            PlayerPrefs.SetInt("achieve_key9", 0);
        }




        if (!PlayerPrefs.HasKey("buy_key"))
        {
            PlayerPrefs.SetInt("buy_key", 1);
        }

        if (!PlayerPrefs.HasKey("buy_key1"))
        {
            PlayerPrefs.SetInt("buy_key1", 0);
        }

        if (!PlayerPrefs.HasKey("buy_key2"))
        {
            PlayerPrefs.SetInt("buy_key2", 0);
        }

        if (!PlayerPrefs.HasKey("buy_key3"))
        {
            PlayerPrefs.SetInt("buy_key3", 0);
        }

        if (!PlayerPrefs.HasKey("buy_key4"))
        {
            PlayerPrefs.SetInt("buy_key4", 0);
        }

        if (!PlayerPrefs.HasKey("buy_key5"))
        {
            PlayerPrefs.SetInt("buy_key5", 0);
        }

        if (!PlayerPrefs.HasKey("buy_key6"))
        {
            PlayerPrefs.SetInt("buy_key6", 0);
        }

        if (!PlayerPrefs.HasKey("buy_key7"))
        {
            PlayerPrefs.SetInt("buy_key7", 0);
        }

        if (!PlayerPrefs.HasKey("buy_key8"))
        {
            PlayerPrefs.SetInt("buy_key8", 0);
        }

        if (!PlayerPrefs.HasKey("ing_key"))
        {
            PlayerPrefs.SetInt("ing_key", 0);
        }

        if(!PlayerPrefs.HasKey("game_over"))
        {
            PlayerPrefs.SetInt("game_over", 0);
        }

        if (!PlayerPrefs.HasKey("go_title")) //인게임에서 타이틀 화면으로 갈때만 샷시 등장
        {
            PlayerPrefs.SetInt("go_title", 0);
        }

        if (!PlayerPrefs.HasKey("go_main")) //상점과 앨범에서 뒤로가기 시 메인화면 표시 (타이틀 X)
        {
            PlayerPrefs.SetInt("go_main", 0);
        }

        if (!PlayerPrefs.HasKey("bgm_sound"))
        {
            PlayerPrefs.SetFloat("bgm_sound", 0.5f);
        }

        if (!PlayerPrefs.HasKey("sfx_sound"))
        {
            PlayerPrefs.SetFloat("sfx_sound", 0.5f);
        }

        if (!PlayerPrefs.HasKey("vibe"))
        {
            PlayerPrefs.SetInt("vibe", 0); //0 : 진동 해제, 1 : 진동 설정
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
