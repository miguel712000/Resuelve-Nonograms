using System;
using System.Collections.Generic;

namespace ResuelveNonograms
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Dictionary<int, List<int>> pistasFilas = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> pistasColumnas = new Dictionary<int, List<int>>();

            List<int> digitos = new List<int>();
            List<int> auxDigitos = new List<int>();

            digitos.Add(2);
            digitos.Add(3);
            auxDigitos = digitos;
            pistasFilas.Add(0, auxDigitos);          
            foreach (int pistas in pistasFilas[0])
            {
                Console.WriteLine(pistas);
            }
            digitos.Clear();

            digitos.Add(4);
            digitos.Add(5);
            auxDigitos = digitos;
            pistasFilas.Add(1, auxDigitos);
            foreach (int pistas in pistasFilas[1])
            {
                Console.WriteLine(pistas);
            }
            digitos.Clear();



            digitos.Add(1);
            digitos.Add(1);
            auxDigitos = digitos;
            pistasColumnas.Add(0, auxDigitos);
            foreach (int pistas in pistasColumnas[0])
            {
                Console.WriteLine(pistas);
            }
            digitos.Clear();

            auxDigitos = digitos;
            pistasColumnas.Add(1, auxDigitos);
            foreach (int pistas in pistasColumnas[1])
            {
                Console.WriteLine(pistas);
            }
            digitos.Clear();

            digitos.Add(2);
            digitos.Add(2);
            digitos.Add(2);
            auxDigitos = digitos;
            pistasColumnas.Add(2, auxDigitos);
            foreach (int pistas in pistasColumnas[0])
            {
                Console.WriteLine(pistas);
            }
            digitos.Clear();



            for(int i = 0; i<2; i++) {
                foreach (int pistas in pistasFilas[i])
                {
                    Console.WriteLine(pistas);
                }
            }
            
            foreach (int pistas in pistasFilas[0])
            {
                Console.WriteLine(pistas);
            }
            */

            //Nonogram puzle = new Nonogram(2, 3, pistasFilas, pistasColumnas);


            int[,] pistasFilas = new int[2,2] { {2,0},{1,1} };
            //pistasFilas[0] = new int[2, 0];
            //pistasFilas[1] = new int[1, 1];

            int[] pistasColumnas = new int[3] { 2,1,1};
            //pistasColumnas[0] = new int[2];
            //pistasColumnas[1] = new int[1];
            //pistasColumnas[2] = new int[1];

            Nonogram puzle = new Nonogram(2,3,pistasFilas,pistasColumnas);


            Console.WriteLine(puzle.dameNonogram());

        }
    }
}