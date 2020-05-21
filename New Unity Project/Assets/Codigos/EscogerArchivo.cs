using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class EscogerArchivo : MonoBehaviour
{
    string path;
    int filas, columnas;
    int[][] pistasFilas;
    int[][] pistasColumnas;

    public void AbrirExplorador()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with png","","txt");
   
    }

    public void leerArchivo()
    {
        
    }


}
