using System;
using System.Collections.Generic;
using System.Text;

namespace ResuelveNonograms
{
    class Nonogram
    {
        private int filas, columnas;
        private int[][] pistasFilas;
        private int[][] pistasColumnas;
        private int[][] solucionNonogram;
        private int colLengthPistasFilas;
        private int colLengthPistasColumnas;


        public Nonogram(int filas, int columnas, int[][] pistasFilas, int[][] pistasColumnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.pistasFilas = pistasFilas;
            this.pistasColumnas = pistasColumnas;
            


            //colLengthPistasFilas = pistasFilas.GetLength(0) -1;
            //colLengthPistasColumnas = pistasColumnas.GetLength(0) -1;

        }

        /*public void estableceFilas(int filas)
        {
            this.filas = filas;
        }

        public void estableceColumnas(int columnas)
        {
            this.columnas = columnas;
        }

        public void establecePistasFilas(int[][] pistasFilas)
        {
            this.pistasFilas = pistasFilas;
        }

        public void establecePistasColumnas(int[][] pistasColumnas)
        {
            this.pistasColumnas = pistasColumnas;
        }
        */

        public String damePistasNonogram()
        {
            String texto;
            //int rowLengthPistasFilas = pistasFilas.GetLength(0);
            //int colLengthPistasFilas = pistasFilas.GetLength(1);

            //int rowLengthPistasColumnas = pistasColumnas.GetLength(0);
            //int colLengthPistasColumnas = pistasColumnas.GetLength(1);

            texto = filas + ", " + columnas + "\nFilas\n";

            texto += "{";
            for (int i = 0; i < filas; i++)
            {
                texto += "{";
                for (int j = 0; j < pistasFilas[i].Length; j++)
                {
                    texto += pistasFilas[i][j] + ", ";
                }
                texto += "}";
            }
            texto += "}";
            
            texto += "\nColumnas\n";

            texto += "{";
            for (int i = 0; i < columnas; i++)
            {
                texto += "{";
                for (int j = 0; j < pistasColumnas[i].Length; j++)
                {
                    texto += pistasColumnas[i][j] + ", ";
                }
                texto += "}";
            }
            texto += "}";
            
            return texto;
        }

        /*public int[,] resuelveNonogram()
        {
            int[][] solicionNonogram = new int[filas][];
            solicionNonogram[0] = new int[columnas];
            

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < colLengthPistasFilas; j++)
                {
                    if (pistasFilas[i,j] != 0)
                    {
                        if (pistasFilas[i,j] > (columnas/2))
                        {
                            solucionNonogram[i,]
                        }
                    }

                }

            return solucionNonogram;
        }
        */
    }
}
