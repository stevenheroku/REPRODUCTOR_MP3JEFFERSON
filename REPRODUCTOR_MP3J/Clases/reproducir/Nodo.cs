using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPRODUCTOR_MP3J.Clases.reproducir
{
    class Nodo
    {



        public string direccion;// hace la simulación de la variable Dato
        public Nodo siguiente;// hace simulacion de la variable enlace


        //constructor
        public Nodo(string direcion)
        {
            this.direccion = direcion;
            this.siguiente = null;

        }

        public string getDireccion()
        {
            return direccion;
        }

        public Nodo getSiguinete()
        {
            return siguiente;
        }

        public void setSiguinete(Nodo siguiente)
        {
            this.siguiente = siguiente;
        }

        public void setRegresar(Nodo anterior)
        {
            this.siguiente = anterior;
        }

    }
}
