using System;
using System.Collections.Generic;

namespace ResuelveNonograms
{
    class Program
    {
        static void Main(string[] args)
        {

            int[][] pistasFilas = new int[2][];
            pistasFilas[0] = new int[1] {1};
            pistasFilas[1] = new int[2] {2,3};
            

            int[][] pistasColumnas = new int[3][];
            pistasColumnas[0] = new int[1] {4};
            pistasColumnas[1] = new int[2] {5,6};
            pistasColumnas[2] = new int[1] {7};

            /*
            Console.WriteLine(pistasFilas[0][pistasFilas.GetLength(0)]);
            Console.WriteLine(pistasFilas[1][0]);
            Console.WriteLine(pistasFilas[1][1]);
            Console.WriteLine(pistasColumnas[0][0]);
            Console.WriteLine(pistasColumnas[1][0]);
            Console.WriteLine(pistasColumnas[2][0]);
            */

            Nonogram puzle = new Nonogram(2,3,pistasFilas,pistasColumnas);


            //Console.WriteLine(pistasFilas[1].Length);

            Console.WriteLine(puzle.damePistasNonogram());



        }
    }
}