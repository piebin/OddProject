using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    // Start is called before the first frame update


    string scoreTh = "Assets/TextFiles/score";
    string achieveTh = "Assets/TextFiles/achieve";
    string buyTh = "Assets/TextFiles/buy";

    void Start()
    {
        
        if(File.Exists(scoreTh)==false)
        {
            FileStream sw = new FileStream(scoreTh, FileMode.Create);
            StreamWriter scoreW = new StreamWriter(sw);
            scoreW.Write("0");
            scoreW.Close();
        }

        if (File.Exists(achieveTh) == false)
        {
            FileStream sw = new FileStream(achieveTh, FileMode.Create);
            StreamWriter achieveW = new StreamWriter(sw);
            achieveW.Write("0");
            achieveW.Close();
        }

        if (File.Exists(buyTh) == false)
        {
            FileStream sw = new FileStream(buyTh, FileMode.Create);
            StreamWriter buyW = new StreamWriter(sw);
            buyW.Write("0");
            buyW.Close();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
