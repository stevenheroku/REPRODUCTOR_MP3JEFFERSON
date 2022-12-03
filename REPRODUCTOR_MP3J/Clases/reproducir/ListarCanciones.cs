using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REPRODUCTOR_MP3J.Clases.reproducir
{
    class ListarCanciones
    {

        public Nodo primero;
        public Nodo ultimo;
        public int tam;

        public ListarCanciones()
        {
            primero = null;
            ultimo = null;
            tam = 0;

        }

        //metodo para verificar si la ista contiene datos o no y asi poder eliiminar cancion
        public bool IsEmpty()
        {
            if (primero == null && ultimo == null)
            {
                MessageBox.Show("NO SE A INSERTADO NI UNA CANCIÓN");
                return true;
            }
            else
            {
                MessageBox.Show("SI HAY CANCIONES PARA PODER ELIMINAR");
                return false;
            }
        }


        //metodo para insertar las canciones a las listas y direccionarlas
        public void insertar(String direccion)
        {
            Nodo nuevo = new Nodo(direccion);
            if (primero == null)
            {
                primero = nuevo;
                primero.siguiente = null;
                ultimo = nuevo;
            }
            else
            {
                ultimo.siguiente = nuevo;
                nuevo.siguiente = null;
                ultimo = nuevo;
            }
            tam++;

        }
        //PRUEBA 2

        //elimina un nodo usando la direccion
        public void eliminarNodo(string direcc)
        {
            Nodo actual = new Nodo(direcc);
            actual = primero;
            Nodo anterior = new Nodo(direcc);
            anterior = null;
            bool encontrado = false;

            if (primero != null)
            {
                while (actual != null && encontrado != true)
                {
                    //entra al if solamente si actual
                    if (actual.direccion == direcc)
                    {
                        MessageBox.Show("CANCION ENCONTRADA");

                        //if para poder eliminar la primer cancion de la lista insertada
                        if (actual == primero)
                        {
                            primero = primero.siguiente;

                        }
                        else
                        //if para eliminar la ultima cancion insertada de la lista
                        if (actual == ultimo)
                        {
                            anterior.siguiente = null;
                            ultimo = anterior;
                        }
                        //else para eliminar cualquier cancion que no sea la primera ni la ultima
                        else
                        {
                            anterior.siguiente = actual.siguiente;
                        }
                        MessageBox.Show("SE ELIMINO CANCION DE LA LISTA");
                        encontrado = true;
                        tam--;
                    }
                    anterior = actual;
                    actual = actual.siguiente;
                }
                if (!encontrado)
                {
                    MessageBox.Show("CANCION NO ENCONTRADA");
                }
            }
            else
            {
                MessageBox.Show("\n LA LISTA SE ENCUENTRA VACIA");
            }

        }

        //busca una canción por medio de su ruta
        public bool buscar(String ruta)
        {
            Nodo aux = primero;

            while (aux != null)
            {
                if (aux.direccion.Equals(ruta))
                {
                    return true;
                }
                aux = aux.siguiente;
            }
            return false;
        }

        public void visualizar()
        {
            Nodo n;
            int k = 0;
            n = primero;
            while (n != null)
            {
                Console.WriteLine(n.direccion + " ");
                n = n.siguiente;
                k++;
                Console.WriteLine((k % 15 != 0 ? "" : "\n"));
            }
        }




    }

}
