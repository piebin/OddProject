using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    // Start is called before the first frame update


    string scoreTh = "Assets/TextFiles/score";

    void Start()
    {
        
        if(File.Exists(scoreTh)==false)
        {
            FileStream sw = new FileStream(scoreTh, FileMode.Create);
            StreamWriter scoreW = new StreamWriter(sw);
            scoreW.Write("0");
            scoreW.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
