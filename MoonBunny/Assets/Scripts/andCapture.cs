using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class andCapture : MonoBehaviour
{

    public Camera sshotcamera;
    private int resWidth;
    private int resHeight;
    // Start is called before the first frame update
    void Start()
    {
        resWidth = Screen.width;
        resHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        /*Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();*/

        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        sshotcamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        sshotcamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();




        // Save the screenshot to Gallery/Photos
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(screenShot, "GalleryTest", "Image.png", (success, path) => Debug.Log("Media save result: " + success + " " + path));

        Debug.Log("Permission result: " + permission);

        // To avoid memory leaks
        Destroy(screenShot);
    }
}
