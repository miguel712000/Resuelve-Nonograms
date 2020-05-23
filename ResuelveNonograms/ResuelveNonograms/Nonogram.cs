using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResuelveNonograms
{
    class Nonogram
    {
        private int filas, columnas;
        private int[][] pistasFilas;
        private int[][] pistasColumnas;
        private int[][] solucionNonogram;
        private bool difCero;


        public Nonogram(int filas, int columnas, int[][] pistasFilas, int[][] pistasColumnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.pistasFilas = pistasFilas;
            this.pistasColumnas = pistasColumnas;
            difCero = false;
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

        public void resuelveNonogram()
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
            resolvedor(solucionNonogram, 0, 0);
        }
        
        private int[][] resolvedor(int [][] solucionAct, int filaActual, int columnaActual)
        {
            Console.WriteLine("\nTras empezar funcion");
            imprimeNonogram();

            if (!chequeadorFila(solucionAct,filaActual) || !chequeadorColumna(solucionAct, columnaActual))
            {
                Console.WriteLine("Tras fallar checks");
                solucionAct[filaActual][columnaActual] = -1;
               
                return solucionAct;
            }
            
            //else if (filaActual == filas && columnaActual == columnas)
            //{
            //    solucionNonogram = solucionAct;
            //}

            else
            {
                Console.WriteLine("Tras pasar checks");
                //imprimeNonogram(); //Ver como se está armando la solucion
                solucionNonogram = solucionAct;
                if (filaActual == filas-1 && columnaActual == columnas-1)
                {
                    Console.WriteLine("Filas y columnas completas");
                    if (chequeadorFinal(solucionAct))
                    {
                        Console.WriteLine("Solucion correcta");
                        imprimeNonogram();
                        //solucionNonogram = solucionAct;
                        return solucionNonogram;
                    }
                    else
                    {
                        Console.WriteLine("Solucion incorrecta, reintentar");
                        return solucionNonogram;
                    }   
                }

                if (columnaActual != columnas && difCero)
                {
                    columnaActual++;
                }
                
                if (columnaActual == columnas && filaActual != filas)
                {
                    filaActual++;
                    columnaActual = 0;
                }

                else
                    difCero = true;

                //Console.WriteLine("A evaluar Fila: " + filaActual + " Columna: " + (columnaActual));

                solucionAct[filaActual][columnaActual] = 1;
                Console.WriteLine("Probar con 1 en ["+filaActual+"]["+columnaActual+"]");
                if (resolvedor(solucionAct, filaActual, columnaActual)[filaActual][columnaActual] == 1)
                {
                    //Console.WriteLine("1 correcto");
                    imprimeNonogram();
                    //Console.WriteLine("chequeadorFinal" + chequeadorFinal(solucionAct));
                    if (chequeadorFinal(solucionAct))
                    {
                        //solucionNonogram = solucionAct;
                        Console.WriteLine("Final");
                        imprimeNonogram();
                        Console.WriteLine();
                        return solucionNonogram;
                    }
                }
                else
                {
                    imprimeNonogram();
                    solucionAct[filaActual][columnaActual] = 0;
                    Console.WriteLine("Probar con 0 en [" + filaActual + "][" + columnaActual + "]");
                    if (resolvedor(solucionAct, filaActual, columnaActual)[filaActual][columnaActual]==0)
                    {
                        //Console.WriteLine("0 correcto");
                        imprimeNonogram();
                        //Console.WriteLine("chequeadorFinal" + chequeadorFinal(solucionAct));
                        if (chequeadorFinal(solucionAct))
                        {
                            //solucionNonogram = solucionAct;
                            Console.WriteLine("Final");
                            imprimeNonogram();
                            Console.WriteLine();
                            return solucionNonogram;
                        }
                    }
                }
                return solucionAct;
                
            }
        }
        /*
        private bool chequeadorFila(int[][] solucionActual,int filaActual)
        {
            int nPistaActual = 0;
            bool conclusion = false;

            foreach(int pista in pistasFilas[filaActual])
            {
                int suma = 0; 
                int miniGrupo = 0;

                for (int i = 0; i < columnas; i++)
                {
                    //Console.WriteLine("nPistaActual: "+nPistaActual+". conclusion: "+conclusion+". Pista: "+pista+". suma: "+suma+". miniGrupo: "+miniGrupo+". i: "+i+". solucionActual[filaActual][i]: "+ solucionActual[filaActual][i]+ ". pistasFilas[filaActual].Count(): " + pistasFilas[filaActual].Count());
                    if (solucionActual[filaActual][i] == 1 && nPistaActual == miniGrupo)
                    {
                        suma++;
                        Console.WriteLine("suma: " + suma);
                    }
                    try
                    {
                        if (solucionActual[filaActual][i] == 1 && solucionActual[filaActual][i + 1] == 0)
                        {
                            miniGrupo++;
                        }
                    }
                    catch (System.IndexOutOfRangeException)
                    {

                    }
                    
                }
                if (pista >= suma)
                {
                    conclusion = true;
                    
                }
                else
                {
                    conclusion = false;
                    Console.WriteLine("Fila check: " + conclusion);
                    return conclusion;
                }


                nPistaActual++;
            }
            Console.WriteLine("Fila check: "+conclusion);
            return conclusion;
        }

        */
        private bool chequeadorFila(int[][] solucionActual,int filaActual)
        {
            int nPistaActual = 0;
            bool conclusion = true;

            //Console.WriteLine("pistasFilas Count: " + (pistasFilas[filaActual].Count()));

            foreach (int pista in pistasFilas[filaActual])
            {
                int suma = 0; 
                int miniGrupo = 0;

                for (int i = 0; i < columnas; i++)
                {

                    //Console.WriteLine("miniGrupo: " + miniGrupo + ". pistasFilas[filaActual].Count(): " + (pistasFilas[filaActual].Count()-1));
                    if (miniGrupo > (pistasFilas[filaActual].Count()-1))
                    {
                        conclusion = false;
                        Console.WriteLine("Fila check: " + conclusion);
                        return conclusion;
                    }

                    

                    if (solucionActual[filaActual][i] == 1)
                    {
                        //Console.WriteLine("miniGrupo: " + miniGrupo+". nPistaActual: "+nPistaActual);
                        if (miniGrupo == nPistaActual)
                        {
                            suma++;
                            //Console.WriteLine("suma: " + suma);
                            if (suma > pista)
                            {
                                conclusion = false;
                                Console.WriteLine("Fila check: " + conclusion);
                                return conclusion;
                            }
                        }
                    }
                    try
                    {
                        //Console.WriteLine("i:" + i + ". solucionActual i: " + solucionActual[filaActual][i] + ". solucion Actual i+1: " + solucionActual[filaActual][i+1]);
                        if (solucionActual[filaActual][i] == 0 && solucionActual[filaActual][i + 1] == 1 && suma > 0)
                        {
                            miniGrupo++;
                            //Console.WriteLine("miniGrupo: " + miniGrupo);
                        }
                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        //Console.WriteLine("miniGrupo catch: " + miniGrupo);
                    }

                }

                nPistaActual++;
                //Console.WriteLine("nPistaAct: " + nPistaActual);
            }
            Console.WriteLine("Fila check: "+conclusion);
            return conclusion;

        }

        /*
        private bool chequeadorColumna(int[][] solucionActual,int columnaActual)
        {
            int nPistaActual = 0;
            bool conclusion = false;

            foreach (int pista in pistasColumnas[columnaActual])
            {
                int suma = 0;
                int miniGrupo = 0;

                for (int i = 0; i < filas; i++)
                {
                    if (solucionActual[i][columnaActual] == 1 && nPistaActual == miniGrupo)
                    {
                        suma++;
                    }
                    else if (solucionActual[i][columnaActual] == 0 && i>=1)
                    {
                        if (solucionActual[i - 1][columnaActual] == 1)
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
                    Console.WriteLine("Columna check: " + conclusion);
                    return conclusion;
                }

                nPistaActual++;

            }

            Console.WriteLine("Columna check: "+conclusion);
            return conclusion;
        }
        */


        private bool chequeadorColumna(int[][] solucionActual, int columnaActual)
        {
            int nPistaActual = 0;
            bool conclusion = true;

            //Console.WriteLine("pistasFilas Count: " + (pistasFilas[filaActual].Count()));

            foreach (int pista in pistasColumnas[columnaActual])
            {
                int suma = 0;
                int miniGrupo = 0;

                for (int i = 0; i < filas; i++)
                {

                    //Console.WriteLine("miniGrupo: " + miniGrupo + ". pistasFilas[filaActual].Count(): " + (pistasFilas[filaActual].Count()-1));
                    if (miniGrupo > (pistasColumnas[columnaActual].Count()-1))
                    {
                        conclusion = false;
                        Console.WriteLine("Columna check: " + conclusion);
                        return conclusion;
                    }



                    if (solucionActual[i][columnaActual] == 1)
                    {
                        //Console.WriteLine("miniGrupo: " + miniGrupo+". nPistaActual: "+nPistaActual);
                        if (miniGrupo == nPistaActual)
                        {
                            suma++;
                            //Console.WriteLine("suma: " + suma);
                            if (suma > pista)
                            {
                                conclusion = false;
                                Console.WriteLine("Columna check: " + conclusion);
                                return conclusion;
                            }
                        }
                    }
                    try
                    {
                        //Console.WriteLine("i:" + i + ". solucionActual i: " + solucionActual[filaActual][i] + ". solucion Actual i+1: " + solucionActual[filaActual][i+1]);
                        if (solucionActual[i][columnaActual] == 0 && solucionActual[i + 1][columnaActual] == 1 && suma > 0)
                        {
                            miniGrupo++;
                            //Console.WriteLine("miniGrupo: " + miniGrupo);
                        }
                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        //Console.WriteLine("miniGrupo catch: " + miniGrupo);
                    }

                }

                nPistaActual++;
                //Console.WriteLine("nPistaAct: " + nPistaActual);
            }
            Console.WriteLine("Columna check: " + conclusion);
            return conclusion;

        }

        private bool chequeadorFinal(int[][] solucionActual)
        {
            bool conclusion = true;
            //Primero chequea todas las filas para ver si su valor satisface el de las pistas

            for (int filaActual = 0; filaActual < pistasFilas.Count(); filaActual++)
            {
                int nPistaActual = 0;
                foreach (int pista in pistasFilas[filaActual])
                {
                    int suma = 0;
                    int miniGrupo = 0;

                    for (int i = 0; i < columnas; i++)
                    {
                        if (solucionActual[filaActual][i] == 1 && nPistaActual == miniGrupo)
                        {
                            suma++;
                        }
                        else if (solucionActual[filaActual][i] == 0 && i >= 1)
                        {
                            if (solucionActual[filaActual][i - 1] == 1)
                                miniGrupo++;
                        }
                    }

                    if (pista == suma)
                    {
                        conclusion = true;

                    }
                    else
                    {
                        conclusion = false;
                        Console.WriteLine("Check Final Filas: " + conclusion);
                        return conclusion;
                    }

                    //Console.WriteLine("Check Final Filas: " + conclusion);
                    nPistaActual++;
                }
                //Console.WriteLine("Check Final Filas: " + conclusion);
                //return conclusion;
            }

            /*
             
             */

            Console.WriteLine("Check Final Filas: " + conclusion);

            for (int columnaActual = 0; columnaActual < pistasColumnas.Count(); columnaActual++)
            {
                int nPistaActual = 0;

                foreach (int pista in pistasColumnas[columnaActual])
                {
                    int suma = 0;
                    int miniGrupo = 0;

                    for (int i = 0; i < filas; i++)
                    {
                        if (solucionActual[i][columnaActual] == 1 && nPistaActual == miniGrupo)
                        {
                            suma++;
                        }
                        else if (solucionActual[i][columnaActual] == 0 && i >= 1)
                        {
                            if (solucionActual[i - 1][columnaActual] == 1)
                                miniGrupo++;
                        }
                    }
                    if (pista == suma)
                    {
                        conclusion = true;
                    }
                    else
                    {
                        conclusion = false;
                        Console.WriteLine("Check Final Columnas: " + conclusion);
                        return conclusion;
                    }
                    //Console.WriteLine("Check Final Columnas: " + conclusion);
                    nPistaActual++;
                }
            }
            Console.WriteLine("Check Final Columnas: " + conclusion);
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

            Console.Write(texto);
        }

    }
}
