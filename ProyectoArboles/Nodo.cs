using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArboles
{
    public class Nodo
    {
        public Nodo izquierda { get; set; }
        public Nodo derecha { get; set; }
        public int dato { get; set; }

        public Nodo()
        {
            this.izquierda = null;
            this.derecha = null;
            this.dato = 0;
        }

        public Nodo(int dato)
        {
            this.izquierda = null;
            this.derecha = null;
            this.dato = dato;
        }

    }
}
