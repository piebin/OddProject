using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Android;

public class ScreenShot : MonoBehaviour
{
    public Camera sshotcamera;
    public GameObject imgName;
    private int resWidth;
    private int resHeight;
    string path;

    void Start()
    {
        resWidth = Screen.width;
        resHeight = Screen.height;


        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            // The user authorized use of the microphone.
        }
        else
        {

            Permission.RequestUserPermission(Permission.Microphone);

        }

        //path = Application.dataPath + "/ScreenShot/";

    }

    public void ClickScreenShot()
    {
        path = Application.dataPath + "/ScreenShot/";

        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);
        }

        string name;
        //path = Application.persistentDataPath + "/" + name;
        name = path + imgName.GetComponent<SpriteRenderer>().sprite.name + ".png";



        /*        string folderLocation = "/storage/emulated/0/DCIM/MyFolder/";
                string myScreenShotLocation = folderLocation + name;

                if(!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }*/


        //¹Ì¿Ï


       
        
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        sshotcamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        sshotcamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();

        byte[] bytes = screenShot.EncodeToPNG();
        File.WriteAllBytes(name, bytes);

        Debug.Log("downloaded");
    }


}
