using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System;
using System.Linq;

public class EscogerArchivo : MonoBehaviour
{
    public string path;
    public int filas, columnas;
    public int[][] pistasFilas;
    public int[][] pistasColumnas;
    public static EscogerArchivo instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }



    public void AbrirExplorador()
    {
        
        path = EditorUtility.OpenFilePanel("Overwrite with png", "", "txt");
        leerArchivo(path);
             
    }



    public void leerArchivo(string pathP)
    {
        Debug.Log("Entro.");
        string fi = "FILAS";
        string co = "COLUMNAS";
        StreamReader sr = new StreamReader(pathP);
        sr.BaseStream.Seek(0, SeekOrigin.Begin);

        string str = sr.ReadLine();
        string[] lineaDividida = str.Split(',');
        filas = Int32.Parse(lineaDividida[0]);
        columnas = Int32.Parse(lineaDividida[1]);

        List<List<int>> listaFinalFilas = new List<List<int>>();
        List<List<int>> listaFinalColumnas = new List<List<int>>();
        str = sr.ReadLine();

        while (str != null)
        {

            if (str.Equals(fi))
            {
                str = sr.ReadLine();
                while (str != "COLUMNAS")
                {
                    bool contiene = str.Contains(",");
                    if (contiene)
                    {
                        string linea = str.Replace(" ", string.Empty);
                        string[] variasPistas = linea.Split(',');

                        int k;
                        List<int> listaPistaVaria = new List<int>();

                        for (k = 0; k < variasPistas.Length; k++)
                        {
                            int valorPista = Int32.Parse(variasPistas[k]);
                            listaPistaVaria.Add(valorPista);

                        }
                        listaFinalFilas.Add(listaPistaVaria);

                        str = sr.ReadLine();

                    }
                    else
                    {
                        List<int> listaPistaSola = new List<int>();
                        int pistaSola = Int32.Parse(str);
                        listaPistaSola.Add(pistaSola);
                        listaFinalFilas.Add(listaPistaSola);
                        str = sr.ReadLine();
                    }

                }

            }

            if (str.Equals("COLUMNAS"))
            {
                str = sr.ReadLine();
            }
            else
            {

                bool contieneC = str.Contains(",");

                if (contieneC)
                {
                    string lineaC = str.Replace(" ", string.Empty);
                    string[] variasPistasCol = lineaC.Split(',');


                    int j;
                    List<int> listaPistaCol = new List<int>();
                    for (j = 0; j < variasPistasCol.Length; j++)
                    {
                        int valorPistaCol = Int32.Parse(variasPistasCol[j]);
                        listaPistaCol.Add(valorPistaCol);

                    }
                    listaFinalColumnas.Add(listaPistaCol);
                    str = sr.ReadLine();

                }
                else
                {
                    List<int> listaPistaSolaCol = new List<int>();
                    int pistaSolaCol = Int32.Parse(str);
                    listaPistaSolaCol.Add(pistaSolaCol);
                    listaFinalColumnas.Add(listaPistaSolaCol);
                    str = sr.ReadLine();
                }


            }


        }

        pistasFilas = listaFinalFilas.Select(a => a.ToArray()).ToArray();
        pistasColumnas = listaFinalColumnas.Select(a => a.ToArray()).ToArray();
        sr.Close();
    }
}
