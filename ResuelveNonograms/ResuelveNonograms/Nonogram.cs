using System;
using System.Collections.Generic;
using System.Text;

namespace ResuelveNonograms
{
    class Nonogram
    {
        private int filas, columnas;
        private Dictionary<int,List<int>> pistasFilas, pistasColumnas;



        public Nonogram(int filas, int columnas, Dictionary<int, List<int>> pistasFilas, Dictionary<int, List<int>> pistasColumnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.pistasFilas = pistasFilas;
            this.pistasColumnas = pistasColumnas;

        }

        public void estableceFilas(int filas)
        {
            this.filas = filas;
        }

        public void estableceColumnas(int columnas)
        {
            this.columnas = columnas;
        }

        public void establecePistasFilas(Dictionary<int, List<int>> pistasFilas)
        {
            this.pistasFilas = pistasFilas;
        }

        public void establecePistasColumnas(Dictionary<int, List<int>> pistasColumnas)
        {
            this.pistasColumnas = pistasColumnas;
        }

        public String dameNonogram()
        {
            String texto;

            texto = filas + ", " + columnas + "\nFilas\n";

            for(int i = 0; i < pistasFilas.Count - 1; i++)
            {
                foreach(int pista in pistasFilas[i])
                {
                    texto += pista + ", ";
                }
            }

            texto += "\nColumnas\n";

            for (int i = 0; i < pistasColumnas.Count - 1; i++)
            {
                foreach (var pista in pistasColumnas[i])
                {
                    Console.WriteLine(pista);
                    texto += pista + ", ";
                }
            }

            return texto;
        }
        
    }
}
