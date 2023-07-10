using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(Camera))]
public class SnapshotCamera : MonoBehaviour
{
    public string name;
    string path = "./Assets/Text/labels.сsv";

    Camera snapCam;

    int resWidth = 256;
    int resHeight = 256;

    void Awake()
    {
        snapCam = GetComponent<Camera>();
        if (snapCam.targetTexture == null)
        {
            snapCam.targetTexture = new RenderTexture(resHeight, resHeight, 24);
        }
        else
        {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }
        snapCam.gameObject.SetActive(false);

    }

        
    public void CallTakeSnapshot()
    {
        snapCam.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if (snapCam.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string fileName = SnapshotName();
            System.IO.File.WriteAllBytes(fileName, bytes);

            // добавление в файл метки класса объекта
            // .. (да, коряво., да мешаю логику, но как есть..)
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(name + ",");
            }


            Debug.Log("Snapshot taken!");
            snapCam.gameObject.SetActive(false);



        }
    }

    string SnapshotName()
    {
        return string.Format("{0}/Snapshots/snap_{1}x{2}_{3}.png",
            Application.dataPath,
            resWidth,
            resHeight,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

 
}
