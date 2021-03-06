﻿using System;
using System.Collections.Generic;

namespace ResuelveNonograms
{
    class Program
    {
        static void Main(string[] args)
        {

            int filas, columnas;

            /*
            filas = 1;
            columnas = 5;
            
            int[][] pistasFilas = new int[filas][];
            pistasFilas[0] = new int[3] { 1,1,1 };


            int[][] pistasColumnas = new int[columnas][];
            pistasColumnas[0] = new int[1] { 1 };
            pistasColumnas[1] = new int[1] { 0 };
            pistasColumnas[2] = new int[1] { 1 };
            pistasColumnas[3] = new int[1] { 0 };
            pistasColumnas[4] = new int[1] { 1 };
            */
            /*
            filas = 2;
            columnas = 3;

            int[][] pistasFilas = new int[filas][];
            pistasFilas[0] = new int[1] { 1 };
            pistasFilas[1] = new int[1] { 2 };


            int[][] pistasColumnas = new int[columnas][];
            pistasColumnas[0] = new int[1] { 0 };
            pistasColumnas[1] = new int[1] { 1 };
            pistasColumnas[2] = new int[1] { 2 };
            */

            
            filas = 5;
            columnas = 5;

            int[][] pistasFilas = new int[filas][];
            pistasFilas[0] = new int[1] { 5 };
            pistasFilas[1] = new int[3] { 1, 1, 1 };
            pistasFilas[2] = new int[1] { 5 };
            pistasFilas[3] = new int[1] { 1 };
            pistasFilas[4] = new int[1] { 1 };

            int[][] pistasColumnas = new int[columnas][];
            pistasColumnas[0] = new int[1] { 5 };
            pistasColumnas[1] = new int[2] { 1, 1 };
            pistasColumnas[2] = new int[1] { 3 };
            pistasColumnas[3] = new int[2] { 1, 1 };
            pistasColumnas[4] = new int[1] { 3 };
            

            /*
            filas = 5;
            columnas = 1;

            int[][] pistasFilas = new int[filas][];
            pistasFilas[0] = new int[1] { 1 };
            pistasFilas[1] = new int[1] { 1 };
            pistasFilas[2] = new int[1] { 1 };
            pistasFilas[3] = new int[1] { 0 };
            pistasFilas[4] = new int[1] { 0 };

            int[][] pistasColumnas = new int[columnas][];
            pistasColumnas[0] = new int[1] { 3 };
            */
            /*
            filas = 2;
            columnas = 3;

            int[][] pistasFilas = new int[filas][];
            pistasFilas[0] = new int[1] { 1 };
            pistasFilas[1] = new int[2] { 1,1 };

            int[][] pistasColumnas = new int[columnas][];
            pistasColumnas[0] = new int[1] { 2 };
            pistasColumnas[1] = new int[1] { 0 };
            pistasColumnas[2] = new int[1] { 1 };
            */
            /*
            filas = 3;
            columnas = 2;
            
            int[][] pistasFilas = new int[filas][];
            pistasFilas[0] = new int[1] { 2 };
            pistasFilas[1] = new int[1] { 0 };
            pistasFilas[2] = new int[1] { 1 };

            int[][] pistasColumnas = new int[columnas][];
            pistasColumnas[0] = new int[1] { 1 };
            pistasColumnas[1] = new int[2] { 1, 1 };
            */
            /*
            filas = 6;
            columnas = 6;

            int[][] pistasFilas = new int[filas][];
            pistasFilas[0] = new int[2] { 2,1 };
            pistasFilas[1] = new int[2] { 1,3 };
            pistasFilas[2] = new int[2] { 1,2 };
            pistasFilas[3] = new int[1] { 3 };
            pistasFilas[4] = new int[1] { 4 };
            pistasFilas[5] = new int[1] { 1 };

            int[][] pistasColumnas = new int[columnas][];
            pistasColumnas[0] = new int[1] { 1 };
            pistasColumnas[1] = new int[1] { 5 };
            pistasColumnas[2] = new int[1] { 2 };
            pistasColumnas[3] = new int[1] { 5 };
            pistasColumnas[4] = new int[2] { 2,1 };
            pistasColumnas[5] = new int[1] { 2 };
            */

            Nonogram puzle = new Nonogram(filas,columnas,pistasFilas,pistasColumnas);

            //Console.WriteLine(puzle.damePistasNonogram());

            puzle.resuelveNonogram();

            puzle.imprimeNonogram();

            

        }
    }
}