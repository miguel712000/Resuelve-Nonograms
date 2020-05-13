using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{
    string path;

    public void AbrirExplorador()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with png","","txt");
        StreamReader sr = new StreamReader(path);
        sr.BaseStream.Seek(0, SeekOrigin.Begin);
        string str = sr.ReadLine();
        while (str != null)
        {
            str = sr.ReadLine();
        }

        // to close the stream 
        sr.Close();
    }


}
