using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class SaveToPng : MonoBehaviour {

    // Use this for initialization
    public Shader outShader;
    public Texture inputTex;
    public Camera Rendercamera;
    public int FileCounter = 0;

    // Use this for initialization
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(buttonClicked);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buttonClicked()
    {
       // SaveRenderTextureToPNG(Rendercamera.targetTexture, outShader, Application.dataPath + "/temp", "ok.png");
        Debug.Log("SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"+Application.dataPath);
        save();


    }

    //public void save()
    //{
    //    RenderTexture rt = Rendercamera.targetTexture;

    //    RenderTexture.active = rt;
    //    Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
    //    tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
    //    RenderTexture.active = null;

    //    byte[] bytes;
    //    bytes = tex.EncodeToPNG();

    //    string path = AssetDatabase.GetAssetPath(rt) + ".png";
    //    System.IO.File.WriteAllBytes(path, bytes);
    //    AssetDatabase.ImportAsset(path);
    //    Debug.Log("Saved to " + path);
    //}

    public void save()
    {
        Camera Cam = Rendercamera;

        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = Cam.targetTexture;

        Cam.Render();

        Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
        Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
        Image.Apply();
        RenderTexture.active = currentRT;

        var Bytes = Image.EncodeToPNG();
        Destroy(Image);

        File.WriteAllBytes(Application.dataPath +"/GG.png", Bytes);
        FileCounter++;
    }
}
