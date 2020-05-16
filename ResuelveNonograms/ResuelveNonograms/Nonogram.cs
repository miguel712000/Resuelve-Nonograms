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


        public Nonogram(int filas, int columnas, int[][] pistasFilas, int[][] pistasColumnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.pistasFilas = pistasFilas;
            this.pistasColumnas = pistasColumnas;

            solucionNonogram = resuelveNonogram();
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
   
            return resolvedor(solucionNonogram,0,0);
        }
        
        public int[][] resolvedor(int [][] solucionAct, int filaActual, int columnaActual)
        {
            if (chequeadorFila(solucionAct, filaActual) == false && chequeadorColumna(solucionAct, columnaActual) == false)
            {
                return solucionAct;
            }
            else
            {
                if(filaActual == filas && columnaActual == columnas) 
                {
                    return solucionAct;
                }
                if (filaActual <= filas)
                {
                    filaActual++;
                }
                else
                {
                    columnaActual++;
                    filaActual = 0;
                }
                solucionAct[filaActual][columnaActual] = 1;
                resolvedor(solucionAct, filaActual, columnaActual);
                solucionAct[filaActual][columnaActual] = 0;
                resolvedor(solucionAct, filaActual, columnaActual);
                return solucionAct;

            }
        }

        public bool chequeadorFila(int[][]solucionActual,int filaActual)
        {
            int nPistaActual = 0;
            bool conclusion = false;

            foreach(int pista in pistasFilas[filaActual])
            {
                int suma = 0; 
                int miniGrupo = 0;

                for (int i = 0; i < columnas; i++)
                {
                    if (solucionActual[filaActual][i] > 0 && nPistaActual == miniGrupo)
                    {
                        suma++;
                    }
                    else if (solucionActual[filaActual][i] == 0 && solucionActual[filaActual][i - 1] == 1)
                    {
                        miniGrupo++;
                    }
                }

                if (pista >= suma)
                {
                    conclusion = true;
                }
                else
                {
                    conclusion = false;
                }

                nPistaActual++;
            }

            return conclusion;
        }

        public bool chequeadorColumna(int[][] solucionActual, int columnaActual)
        {
            int nPistaActual = 0;
            bool conclusion = false;

            foreach (int pista in pistasColumnas[columnaActual])
            {
                int suma = 0;
                int miniGrupo = 0;

                for (int i = 0; i < filas; i++)
                {
                    if (solucionActual[columnaActual][i] > 0 && nPistaActual == miniGrupo)
                    {
                        suma++;
                    }
                    else if (solucionActual[columnaActual][i] == 0 && solucionActual[columnaActual][i - 1] == 1)
                    {
                        miniGrupo++;
                    }
                }
                if (pista >= suma)
                {
                    conclusion = true;
                }
                else
                {
                    conclusion = false;
                }

                nPistaActual++;

            }

            return conclusion;
        }

        public void imprimeNonogram()
        {
            string texto = "";

            foreach(int[] filas in solucionNonogram)
            {
                foreach(int columna in filas)
                {
                    texto += columna + ",";
                }
                texto += "\n";
            }
            Console.WriteLine(texto);
        }

    }
}
