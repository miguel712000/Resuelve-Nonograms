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

        public int[][] resuelveNonogram()
        {
            int[][] solicionNonogram = new int[filas][];
            for (int i = 0; i < filas; i++)
            {
                solicionNonogram[i] = new int[columnas];
                for (int j = 0; j< columnas; j++)
                {
                    solicionNonogram[i][j] = -1;
                }
            }

            //TODO resolvedor


   
            return solucionNonogram;
        }
        
        public void resolvedor(int [][] solucionAct, int columnaSolucion, int filaSolucion)
        {
            if (columnaSolucion==columnas && filaSolucion == filas)
            {
                Console.WriteLine(solucionAct);
            }
            else
            {
                solucionAct[columnaSolucion][filaSolucion] = 1;
                resolvedor(solucionAct, columnaSolucion, filaSolucion + 1);
                solucionAct[columnaSolucion][filaSolucion] = 0;
                resolvedor(solucionAct, columnaSolucion, filaSolucion + 1);
            }
        }

    }
}
