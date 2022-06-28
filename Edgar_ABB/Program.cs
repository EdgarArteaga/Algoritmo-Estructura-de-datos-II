using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgar_ABB
{
    class Nodo
    {
        public int altura;
        public int info;
        public Nodo izq;
        public Nodo der;

        public Nodo(int d)
        {
            info = d;
            altura = 1;
        }
    }
    class ArbolBalanceado
    {
        Nodo Raiz;
        public void Limpiar()
        {
            Raiz = null;
        }
        public void Insertar(int clave)
        {
            Raiz = InsertarBalanceado(Raiz, clave);
        }
        private Nodo InsertarBalanceado(Nodo nodoActual, int key)
        {
            if (nodoActual == null)
            {
                return (new Nodo(key));
            }
            if (key < nodoActual.info)
            {
                nodoActual.izq = InsertarBalanceado(nodoActual.izq, key);
            }
            else if (key > nodoActual.info)
            {
                nodoActual.der = InsertarBalanceado(nodoActual.der, key);
            }
            else
            {// Si la clave esta duplicada retorna el mismo nodo encontrado
                return nodoActual;
            }
            // Actualizacion de la altura
            nodoActual.altura = 1 +
            Max(Altura(nodoActual.izq), Altura(nodoActual.der));

            //Se obtiene el factor de equilibrio
            int fe = FactorEquilibrio(nodoActual);

            if (fe > 1 && key < nodoActual.izq.info)
            {
                return RotacionDer(nodoActual);
            }

            // Caso Rotacion Simple a la izquierda
            
            if (fe < -1 && key > nodoActual.der.info)
            {
                return RotacionIzq(nodoActual);
            }
            // Caso Rotacion Doble Izquierda Derecha
            
            if (fe > 1 && key > nodoActual.izq.info)
            {// aca vengo
                nodoActual.izq = RotacionIzq(nodoActual.izq);
                return RotacionDer(nodoActual);
            }

            // Caso Rotacion Doble Derecha Izquierda
            if (fe < -1 && key < nodoActual.der.info)
            {
                nodoActual.der = RotacionDer(nodoActual.der);
                return RotacionIzq(nodoActual);
            }

            return nodoActual;
        }
        public  Nodo RotacionDer(Nodo nodoActual)// rotacion simple 
        {
            Nodo nuevaRaiz = nodoActual.izq;
            Nodo temp = nuevaRaiz.der;

            //  Se realiza la rotacion
            nuevaRaiz.der = nodoActual;
            nodoActual.izq = temp;

            //   Actualiza alturas
            nodoActual.altura = Max(Altura(nodoActual.izq), Altura(nodoActual.der)) + 1;
            nuevaRaiz.altura = Max(Altura(nuevaRaiz.izq), Altura(nuevaRaiz.der)) + 1;

            return nuevaRaiz;
        }

        // Rotar hacia la izquierda
        private Nodo RotacionIzq(Nodo nodoActual)
        {
            Nodo nuevaRaiz = nodoActual.der;
            Nodo temp = nuevaRaiz.izq;

            // Se realiza la rotacion
            nuevaRaiz.izq = nodoActual;
            nodoActual.der = temp;

            // Actualiza alturas
            nodoActual.altura = Max(Altura(nodoActual.izq), Altura(nodoActual.der)) + 1;
            nuevaRaiz.altura = Max(Altura(nuevaRaiz.izq), Altura(nuevaRaiz.der)) + 1;

            return nuevaRaiz;
        }
        private int Altura(Nodo nodoActual)
        {
            if (nodoActual == null)
            {
                return 0;
            }

            // Notar que no es necesario recorrer el arbol para conocer la altura del nodo
            // debido a que en las rotaciones se incluye la actualizacion de las alturas respectivas
            return nodoActual.altura;
        }

        //Devuelve el mayor entre dos numeros
        private int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        //Obtiene el factor de equilibrio de un nodo
        private int FactorEquilibrio(Nodo nodoActual)
        {
            if (nodoActual == null)
            {
                return 0;
            }
            return Altura(nodoActual.izq) - Altura(nodoActual.der);
        }
        public  void Invocar()
        {
            Mostrar(Raiz, 0);   
        }
        private void Mostrar(Nodo nodo, int c)
        {
            if (nodo != null)
            {
                Mostrar(nodo.der, c + 1);
                for (int i = 0; i < c; i++)
                {
                    Console.Write("       ");
                }
                Console.WriteLine("({0})", nodo.info);
                Mostrar(nodo.izq, c + 1);
            }
        }
    }
    class Program
    {
        public static int Menu()
        {
            int op;
            Console.Clear();
            Console.WriteLine("---------Arbol Balanceado------------");
            Console.WriteLine("1.- Insertar");
            Console.WriteLine("2.- Mostarr");
            Console.WriteLine("3.- Salir");
            Console.Write("Opcion: "); op = int.Parse(Console.ReadLine());
            return op;
        }
        static void Main(string[] args)
        {
            ArbolBalanceado arbol = new ArbolBalanceado();
            arbol.Insertar(8);
            arbol.Insertar(9);
            arbol.Insertar(11);
            arbol.Insertar(15);
            arbol.Insertar(19);
            arbol.Insertar(20);
            arbol.Insertar(21);
            arbol.Insertar(7);
            arbol.Insertar(3);
            arbol.Insertar(2);
            arbol.Insertar(1);
            arbol.Insertar(5);
            arbol.Insertar(6);
            arbol.Insertar(4);
            arbol.Insertar(13);
            arbol.Insertar(14);
            arbol.Insertar(10);
            arbol.Insertar(12);
            arbol.Insertar(17);
            arbol.Insertar(16);
            arbol.Insertar(18);
            arbol.Invocar();
            Console.ReadKey();
        }
     
        }
    }
  
