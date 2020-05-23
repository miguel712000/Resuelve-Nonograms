using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFinal : MonoBehaviour
{
    [SerializeField]
    public int rows;
    [SerializeField]
    public int cols;
    [SerializeField]
    public float tileSize = 1;
    private int[][] solucionNonogram;

    public void CorrerNono()
    {
        Nonogram.nonogramInstance.resuelveNonogram();
        GeneradorGridFinal();
    }
    public void GeneradorGridFinal()
    {
        rows = EscogerArchivo.instance.filas;
        cols = EscogerArchivo.instance.columnas;
        GameObject comodin = (GameObject)Instantiate(Resources.Load("verde"));

        solucionNonogram = Nonogram.nonogramInstance.getSolucionNonogram();


        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (solucionNonogram[row][col] == 1)
                {
                    GameObject tile = (GameObject)Instantiate(comodin, transform);

                    float posX = col * tileSize;
                    float posY = row * -tileSize;

                    tile.transform.position = new Vector2(posX, posY);
                }
                

            }
        }

        Destroy(comodin);

        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
    }
}
