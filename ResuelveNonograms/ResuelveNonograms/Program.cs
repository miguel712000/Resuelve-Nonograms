using System;
using System.Collections.Generic;

namespace ResuelveNonograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> pistasFilas = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> pistasColumnas = new Dictionary<int, List<int>>();

            List<int> digitos = new List<int>();
            digitos.Add(2);
            digitos.Add(3);

            pistasFilas.Add(0, digitos);
            digitos.Clear();

            digitos.Add(4);
            digitos.Add(5);

            pistasFilas.Add(1, digitos);
            digitos.Clear();

            

            digitos.Add(1);
            digitos.Add(1);

            pistasColumnas.Add(0, digitos);
            digitos.Clear();

            pistasColumnas.Add(1, digitos);
            digitos.Clear();

            digitos.Add(2);
            digitos.Add(2);
            digitos.Add(2);

            pistasColumnas.Add(2, digitos);
            digitos.Clear();

            {
                Nonogram puzle = new Nonogram(2, 3, pistasFilas, pistasColumnas);

                Console.WriteLine(puzle.dameNonogram());
            }
        }
    }
}