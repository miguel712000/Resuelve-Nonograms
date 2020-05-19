using System;
using System.Collections.Generic;

namespace ResuelveNonograms
{
    class Program
    {
        static void Main(string[] args)
        {

            int filas, columnas;

            filas = 2;
            columnas = 3;

            int[][] pistasFilas = new int[filas][];
            pistasFilas[0] = new int[1] {1};
            pistasFilas[1] = new int[1] {2};
            

            int[][] pistasColumnas = new int[columnas][];
            pistasColumnas[0] = new int[1] {0};
            pistasColumnas[1] = new int[1] {1};
            pistasColumnas[2] = new int[1] {1};

            //Console.WriteLine(pistasColumnas[0][0]);

            Nonogram puzle = new Nonogram(filas,columnas,pistasFilas,pistasColumnas);

            //Console.WriteLine(puzle.damePistasNonogram());

            puzle.resuelveNonogram();

            puzle.imprimeNonogram();

            

        }
    }
}