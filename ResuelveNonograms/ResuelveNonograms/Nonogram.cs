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
            solucionNonogram = new int[filas][];
            for (int i = 0; i < filas; i++)
            {
                solucionNonogram[i] = new int[columnas];
                for (int j = 0; j< columnas; j++)
                {
                    solucionNonogram[i][j] = -1;
                }
            }

            Console.WriteLine("Solucion inicializada");
            imprimeNonogram();  //Enseña que solucionNonogram si inicia sus valores en -1

            
            return resolvedor(solucionNonogram,0,0);
        }
        
        public int[][] resolvedor(int [][] solucionAct, int filaActual, int columnaActual)
        {
            Console.WriteLine("Tras resolvedor");
            imprimeNonogram();

            if (chequeadorFila(solucionAct,filaActual) == false || chequeadorColumna(solucionAct, columnaActual) == false)
            {
                solucionNonogram = solucionAct;
                Console.WriteLine("Tras verificar");
                imprimeNonogram(); //Ver como se está armando la solucion
                return solucionAct;
            }
            
            //else if (filaActual == filas && columnaActual == columnas)
            //{
            //    solucionNonogram = solucionAct;
            //}

            else
            {
                if (columnaActual <= columnas)
                {
                    columnaActual++;
                }
                else
                {
                    filaActual++;
                    columnaActual = 0;
                }
                solucionAct[filaActual][columnaActual-1] = 1;
                resolvedor(solucionAct, filaActual, columnaActual);
                solucionAct[filaActual][columnaActual-1] = 0;
                resolvedor(solucionAct, filaActual, columnaActual);

                Console.WriteLine("Final");
                imprimeNonogram();
                return solucionNonogram;

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
                    if (solucionActual[filaActual][i] == 1 && nPistaActual == miniGrupo)
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
            Console.WriteLine("Fila check: "+conclusion);
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
                    if (solucionActual[i][columnaActual] > 0 && nPistaActual == miniGrupo)
                    {
                        suma++;
                    }
                    else if (solucionActual[i][columnaActual] == 0 && solucionActual[i-1][columnaActual] == 1)
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

            Console.WriteLine("Columna check: "+conclusion);
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
