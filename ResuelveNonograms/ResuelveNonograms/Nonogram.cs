using System;
using System.Collections.Generic;
using System.Text;

namespace ResuelveNonograms
{
    class Nonogram
    {
        private int filas, columnas;
        private int[,] pistasFilas;
        private int[] pistasColumnas;



        public Nonogram(int filas, int columnas, int[,] pistasFilas, int[] pistasColumnas)
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

        public void establecePistasFilas(int[,] pistasFilas)
        {
            this.pistasFilas = pistasFilas;
        }

        public void establecePistasColumnas(int[] pistasColumnas)
        {
            this.pistasColumnas = pistasColumnas;
        }

        public String dameNonogram()
        {
            String texto;
            int rowLengthPistasFilas = pistasFilas.GetLength(0);
            int colLengthPistasFilas = pistasFilas.GetLength(1);

            int rowLengthPistasColumnas = pistasColumnas.GetLength(0);
            //int colLengthPistasColumnas = pistasColumnas.GetLength(1);

            texto = filas + ", " + columnas + "\nFilas\n";

            texto += "{";
            for (int i = 0; i < rowLengthPistasFilas; i++)
            {
                texto += "{";
                for (int j = 0; j < colLengthPistasFilas; j++)
                {
                    texto += pistasFilas[i,j] + ", ";
                }
                texto += "}";
            }
            texto += "}";

            texto += "\nColumnas\n";

            texto += "{";
            for (int i = 0; i < rowLengthPistasColumnas; i++)
            {
                //texto += "{";
                //for (int j = 0; j < colLengthPistasColumnas; j++)
                //{
                    texto += pistasColumnas[i] + ", ";
                //}
                //texto += "}";
            }
            texto += "}";

            return texto;
        }

    }
}
