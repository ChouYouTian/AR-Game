using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class SaveToPng : MonoBehaviour {

    // Use this for initialization
    public Camera Rendercamera;
    
    public int FileCounter = 3;

    // Use this for initialization
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(buttonClicked);
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Application.dataPath +"/ModelTexture");
        FileCounter = dir.GetFiles().Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buttonClicked()
    {

        Debug.Log("Save PNG to "+Application.dataPath + "/ModelTexture/");
        Debug.Log("File numbers"+FileCounter);
        save();


    }


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
        FileCounter++;
        File.WriteAllBytes(Application.dataPath+"/ModelTexture/Texture_"+FileCounter+".png", Bytes);
        AssetDatabase.Refresh();
        
    }
}
