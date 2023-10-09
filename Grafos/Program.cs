using System;
using System.Collections.Generic;

class Program
    {
        static int numVertices;
        static List<int>[] listaAdyacencia;

        static void Main()
        {
            Console.WriteLine("Aplicación de Grafos en C#");
            Console.WriteLine("=========================");

            Console.Write("Ingrese el número de vértices del grafo: ");
            numVertices = int.Parse(Console.ReadLine());

            listaAdyacencia = new List<int>[numVertices];
            for (int i = 0; i < numVertices; i++)
            {
                listaAdyacencia[i] = new List<int>();
            }

            while (true)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Agregar vértice");
                Console.WriteLine("2. Agregar arista");
                Console.WriteLine("3. Realizar recorrido DFS");
                Console.WriteLine("4. Mostrar matriz de adyacencia");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarVertice();
                        break;

                    case 2:
                        AgregarArista();
                        break;

                    case 3:
                        RealizarRecorridoDFS();
                        break;

                    case 4:
                        MostrarMatrizAdyacencia();
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del programa.");
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        static void AgregarVertice()
        {
            numVertices++;
            Array.Resize(ref listaAdyacencia, numVertices);
            listaAdyacencia[numVertices - 1] = new List<int>();
            Console.WriteLine($"Se agregó el vértice {numVertices - 1}.");
        }

        static void AgregarArista()
        {
            Console.Write("Ingrese el primer vértice (origen): ");
            int origen = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el segundo vértice (destino): ");
            int destino = int.Parse(Console.ReadLine());

            if (origen >= 0 && origen < numVertices && destino >= 0 && destino < numVertices)
            {
                listaAdyacencia[origen].Add(destino);
                listaAdyacencia[destino].Add(origen);
                Console.WriteLine($"Se agregó la arista entre {origen} y {destino}.");
            }
            else
            {
                Console.WriteLine("Vértices no válidos. Asegúrese de que los vértices existan.");
            }
        }

        static void DFSUtil(int vertice, bool[] visitado)
        {
            visitado[vertice] = true;
            Console.Write(vertice + " ");

            foreach (int vecino in listaAdyacencia[vertice])
            {
                if (!visitado[vecino])
                {
                    DFSUtil(vecino, visitado);
                }
            }
        }

        static void RealizarRecorridoDFS()
        {
            Console.Write("Ingrese el vértice de inicio para el recorrido DFS: ");
            int inicio = int.Parse(Console.ReadLine());

            bool[] visitado = new bool[numVertices];
            Console.WriteLine("Recorrido en Profundidad (DFS):");
            DFSUtil(inicio, visitado);
            Console.WriteLine();
        }

        static void MostrarMatrizAdyacencia()
        {
            Console.WriteLine("Matriz de Adyacencia:");
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (listaAdyacencia[i].Contains(j))
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

