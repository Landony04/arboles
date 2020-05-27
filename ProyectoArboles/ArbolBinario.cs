using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArboles
{

    public class ArbolBinario
    {
        public static Nodo raiz { get; set; }
        public int nodos { get; set; }
        public int caminoInterior;
        public int caminoExterior;
        public int gradoMayor;
        public int grado; 
        public int componenteSubArbol;
        public int nivel;
        public Nodo padre;
        public Nodo nodoHijoUno; 
        public Nodo nodoHijoDos;

        public ArbolBinario()
        {
            raiz = null;
            nodos = 0;
        }

        //OBTENER RAIZ

        public Nodo ObtenerRaiz()
        {
            return raiz;
        }

        //VERIFICAR SI EL ARBOL ESTÁ VACÍO

        public bool esRaizVacia()
        {
            return raiz == null;
        }

        //INSERCION DE UN NODO

        public void Insercion(int Dato)
        {
            Console.WriteLine(InsercionNormal(raiz, Dato));
            nodos++;
        }

        public String InsercionNormal(Nodo nodoActual, int nuevoDato)
        {
            if (raiz == null)
            {
                Console.WriteLine("raiz == null");
                Nodo nuevoNodo = new Nodo(nuevoDato);
                raiz = nuevoNodo;
            } else if (nuevoDato < nodoActual.dato)
            {
                Console.WriteLine("nuevoDato < nodoActual.dato");
                if (nodoActual.izquierda == null)
                {
                    Nodo NuevoNodo = new Nodo(nuevoDato);
                    nodoActual.izquierda = NuevoNodo;
                } else
                {
                    InsercionNormal(nodoActual.izquierda, nuevoDato);
                }
            } else if (nuevoDato > nodoActual.dato)
            {
                Console.WriteLine("nuevoDato > nodoActual.dato");
                if (nodoActual.derecha == null)
                {
                    Nodo NuevoNodo = new Nodo(nuevoDato);
                    nodoActual.derecha = NuevoNodo;
                } else
                {
                    InsercionNormal(nodoActual.derecha, nuevoDato);
                }
            }

            return "Se ingreso el nuevo Nodo";
        }

        //COMPROBACION PARA QUE LA LLAVE DE CADA NODO SEA UNICA

        public bool BusquedaComprobacion(int nodoABuscar)
        {
            if (Comprobacion(raiz, nodoABuscar) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Comprobacion(Nodo nodo, int datoComprobar)
        {
            if (nodo != null)
            {
                if (nodo.dato == datoComprobar)
                {
                    return true;
                }
                if (Comprobacion(nodo.izquierda, datoComprobar) == true)
                {
                    return true;
                }
                if (Comprobacion(nodo.derecha, datoComprobar) == true)
                {
                    return true;
                }
            }
            return false;
        }

        //DESCENDIENTES DE UN NODO X

        public void DescendientesNodoX(int nodoX)
        {
            DescendientesNodoXMet(raiz, nodoX);
        }

        public void DescendientesNodoXMet(Nodo nodo, int nodoX)
        {
            if (nodo != null)
            {
                Console.WriteLine("Nodo != null");
                Console.WriteLine(nodo.dato);
                Console.WriteLine(nodoX);
                if (nodo.dato == nodoX)
                {
                    Console.WriteLine("nodo.dato == nodoX");
                    Console.Clear();
                    if (nodo.derecha == null && nodo.izquierda == null)
                    {
                        Console.WriteLine("El Nodo {0} no tiene descendientes", nodo.dato);
                    }
                    else if (nodo.derecha != null && nodo.izquierda == null)
                    {
                        Console.WriteLine("El unico descendiente del Nodo {0} es: ", nodo.dato);
                        Console.WriteLine("{0}   ", nodo.derecha.dato);
                    }
                    else if (nodo.derecha == null && nodo.izquierda != null)
                    {
                        Console.WriteLine("El unico descendiente del Nodo {0} es: ", nodo.dato);
                        Console.WriteLine("{0}   ", nodo.izquierda.dato);
                    }
                    else if (nodo.derecha != null && nodo.izquierda != null)
                    {
                        Console.WriteLine("Los descendientes del Nodo {0} son: ", nodo.dato);
                        Console.WriteLine("{0}   {1}", nodo.izquierda.dato, nodo.derecha.dato);
                    }
                }
                DescendientesNodoXMet(nodo.izquierda, nodoX);
                DescendientesNodoXMet(nodo.derecha, nodoX);
            }
        }

        //PADRE DE UN NODO Y

        public Nodo PadreNodoY(int nodoY)
        {
            padre = null;
            if (raiz.dato == nodoY)
            {
                Console.Clear();
                Console.WriteLine("El nodo ingresado es el nodo raiz");
            }
            else
            {
                PadreNodoYMet(raiz, nodoY);
            }
            return padre;
        }

        public string PadreNodoYMet(Nodo nodoActual, int padreNodoY)
        {
            if (nodoActual != null)
            {
                if (nodoActual.dato == padreNodoY)
                {
                    Console.Clear();
                    return "";
                }
                if (PadreNodoYMet(nodoActual.izquierda, padreNodoY) == "")
                {
                    Console.WriteLine("El padre del nodo {0} es: {1}", padreNodoY, nodoActual.dato);
                    padre = nodoActual;
                }
                if (PadreNodoYMet(nodoActual.derecha, padreNodoY) == "")
                {
                    Console.WriteLine("El padre del nodo {0} es: {1}", padreNodoY, nodoActual.dato);
                    padre = nodoActual;
                }

            }
            return " ";
        }

        //LOS NODOS INTERIORES DE UN ÁRBOL

        public void NodosInteriores()
        {
            if ((raiz.derecha == null && raiz.izquierda == null))
            {
                Console.Clear();
                Console.WriteLine("El arbol no posee nodos internos");
            }
            else if (raiz.izquierda != null && raiz.derecha == null)
            {
                if ((raiz.izquierda.izquierda == null && raiz.izquierda.derecha == null && raiz.derecha == null))
                {
                    Console.Clear();
                    Console.WriteLine("El arbol no posee nodos internos");
                }
                else
                {
                    NodosInterioresMet(raiz);
                }
            }
            else if (raiz.derecha != null && raiz.izquierda == null)
            {
                if ((raiz.derecha.derecha == null && raiz.derecha.izquierda == null && raiz.izquierda == null))
                {
                    Console.Clear();
                    Console.WriteLine("El arbol no posee nodos internos");
                }
                else
                {
                    NodosInterioresMet(raiz);
                }
            }
            else if (raiz.derecha != null && raiz.izquierda != null)
            {
                if ((raiz.izquierda.izquierda == null && raiz.izquierda.derecha == null && raiz.derecha.izquierda == null && raiz.derecha.derecha == null))
                {
                    Console.Clear();
                    Console.WriteLine("El arbol no posee nodos internos");
                }
                else
                {
                    NodosInterioresMet(raiz);
                }
            }
            else
            {
                NodosInterioresMet(raiz);
            }
        }

        public void NodosInterioresMet(Nodo nodo)
        {
            if (nodo != null)
            {
                if ((nodo.derecha != null || nodo.izquierda != null) && nodo != raiz)
                {
                    Console.WriteLine("{0} ", nodo.dato);
                }
                NodosInterioresMet(nodo.izquierda);

                NodosInterioresMet(nodo.derecha);
            }
        }

        //LOS NODOS HOJA DE UN ÁRBOL

        public void NodosHoja()
        {
            NodosHojaMet(raiz);
        }

        public void NodosHojaMet(Nodo nodo)
        {
            if (nodo != null)
            {
                NodosHojaMet(nodo.izquierda);
                if (nodo.izquierda == null && nodo.derecha == null)
                {
                    Console.WriteLine("{0}", nodo.dato);
                }
                NodosHojaMet(nodo.derecha);
            }
        }

        //EL GRADO DE UN NODO X

        public int GradoNodoX(int datoNodo)
        {
            grado = 0;
            return GradoNodoXMet(raiz, datoNodo);
        }

        public int GradoNodoXMet(Nodo nodo, int datoNodo)
        {
            if (nodo != null)
            {
                GradoNodoXMet(nodo.izquierda, datoNodo);
                if ((nodo.izquierda == null && nodo.derecha == null) && nodo.dato == datoNodo)
                {
                    Console.Clear();
                    Console.WriteLine("EL GRADO DEL NODO {0} ES: 0", nodo.dato);
                    grado = 0;
                }
                else if (((nodo.izquierda != null && nodo.derecha == null) || (nodo.izquierda == null && nodo.derecha != null)) && nodo.dato == datoNodo)
                {
                    Console.Clear();
                    Console.WriteLine("EL GRADO DEL NODO {0} ES: 1", nodo.dato);
                    grado = 1;
                }
                else if (nodo.derecha != null && nodo.izquierda != null && nodo.dato == datoNodo)
                {
                    Console.Clear();
                    Console.WriteLine("EL GRADO DEL NODO {0} ES: 2", nodo.dato);
                    grado = 2;
                }
                GradoNodoXMet(nodo.derecha, datoNodo);
            }
            return grado;
        }

        //EL NIVEL DE UN NODO X

        public int NivelNodoX(int datoNodo)
        {
            nivel = 0;
            return NivelNodoXMet(raiz, datoNodo, 1);
        }

        public int NivelNodoXMet(Nodo nodo, int datoNodo, int contador)
        {
            if (nodo != null)
            {
                if (nodo.dato == datoNodo)
                {
                    Console.Clear();
                    Console.WriteLine("El nivel del Nodo {0} es: {1}", datoNodo, contador);
                    nivel = contador;
                }
                contador++;
                NivelNodoXMet(nodo.izquierda, datoNodo, contador);
                NivelNodoXMet(nodo.izquierda, datoNodo, contador);
            }
            return nivel;
        }

        //CAMINO INTERNO

        public void CaminoInterno()
        {
            caminoInterior = 0;
            CaminoInternoMet(raiz, 1);
            Console.Clear();
            Console.WriteLine("LA LONGITUD DEL CAMINO INTERNO DEL ÁRBOL ES: {0}", caminoInterior);
        }

        public void CaminoInternoMet(Nodo nodo, int contador)
        {
            if (nodo != null)
            {
                caminoInterior = caminoInterior + contador;
                contador++;
                CaminoInternoMet(nodo.izquierda, contador);
                CaminoInternoMet(nodo.derecha, contador);
            }
        }

        //CAMINO EXTERNO

        public void CaminoExterno()
        {
            gradoMayor = 0;
            caminoExterior = 0;
            MayorGrado(raiz);
            CaminoExternoMet(raiz);
            Console.Clear();
            Console.WriteLine("LA LONGITUD DE CAMINO EXTERNO DEL ÁRBOL ES: {0}", caminoExterior);
        }

        public void CaminoExternoMet(Nodo nodo)
        {
            try
            {
                if (nodo.izquierda == null && nodo.derecha == null && gradoMayor == 2)
                {
                    int nivel = NivelNodoX(nodo.dato);
                    nivel++;
                    caminoExterior = caminoExterior + (nivel * 2);
                }
                else if (nodo.izquierda == null && nodo.derecha == null && gradoMayor == 1)
                {
                    int nivel = NivelNodoX(nodo.dato);
                    nivel++;
                    caminoExterior = caminoExterior + nivel;
                }
                else if ((nodo.izquierda != null && nodo.derecha == null && gradoMayor == 2) || (nodo.izquierda == null && nodo.derecha != null && gradoMayor == 2))
                {
                    int nivel = NivelNodoX(nodo.dato);
                    nivel++;
                    caminoExterior = caminoExterior + nivel;
                }
                else if ((nodo.izquierda != null && nodo.derecha == null && gradoMayor == 1) || (nodo.izquierda == null && nodo.derecha != null && gradoMayor == 1))
                {
                    int nivel = NivelNodoX(nodo.dato);
                    nivel++;
                    caminoExterior = caminoExterior + nivel;
                }
            }
            catch (NullReferenceException)
            {
                System.Console.WriteLine("Error null");
            }
            if (nodo != null)
            {
                CaminoExternoMet(nodo.izquierda);

                CaminoExternoMet(nodo.derecha);
            }
        }

        //GRADO DE UN ÁRBOL

        public void MayorGrado(Nodo nodo)
        {
            if (nodo != null)
            {
                MayorGrado(nodo.izquierda);
                if (gradoMayor < GradoNodoX(nodo.dato))
                {
                    gradoMayor = GradoNodoX(nodo.dato);
                }
                MayorGrado(nodo.derecha);
            }
        }

        //ELIMINACIÓN NODOS HOJA

        public void EliminarNodosHoja()
        {
            if (raiz.izquierda == null && raiz.derecha == null)
            {
                raiz = null;
            }
            else
            {
                EliminarNodosHojaMet(raiz);
            }
        }

        public void EliminarNodosHojaMet(Nodo nodo)
        {
            try
            {
                if (nodo.izquierda == null && nodo.derecha == null)
                {
                    Nodo nodoTemporal = PadreNodoY(nodo.dato);
                    if (nodoTemporal.derecha == nodo)
                    {
                        nodoTemporal.derecha = null;
                        nodo = null;
                    }
                    else if (nodoTemporal.izquierda == nodo)
                    {
                        nodoTemporal.izquierda = null;
                        nodo = null;
                    }
                }
            }
            catch (NullReferenceException)
            {
                System.Console.WriteLine("Error null");
            }
            if (nodo != null)
            {
                EliminarNodosHojaMet(nodo.izquierda);
                EliminarNodosHojaMet(nodo.derecha);
            }
        }

        //CAMBIAR DE LUGAR DOS NODOS

        public void CambiarLugar(Nodo nodo1, Nodo nodo2)
        {
            bool bandera = false;
            componenteSubArbol = 0;
            if (raiz.dato == nodo1.dato || raiz.dato == nodo2.dato)
            {
                Console.Clear();
                Console.WriteLine("NO SE PUEDE INTERCAMBIAR CON EL NODO RAÍZ");
                bandera = true;
            }
            else
            {
                CambiarLugarMetComp(raiz.izquierda, nodo1, nodo2);
                if (componenteSubArbol == 2)
                {
                    Console.WriteLine("NO SE PUEDE REALIZAR EL CAMBIO PORQUE PERTENECEN A LA MISMA RAMA IZQUIERDA");
                    bandera = true;
                }
                componenteSubArbol = 0;
                CambiarLugarMetComp(raiz.derecha, nodo1, nodo2);
                if (componenteSubArbol == 2)
                {
                    Console.WriteLine("NO SE PUEDE REALIZAR EL CAMBIO PORQUE PERTENECEN A LA MISMA RAMA DERECHA");
                    bandera = true;
                    componenteSubArbol = 0;
                }
            }
            componenteSubArbol = 0;
            if (bandera == false)
            {
                BusquedaDosNodos(raiz, nodo1, nodo2);
                nodo1 = nodoHijoUno;
                nodo2 = nodoHijoDos;
                if (componenteSubArbol == 2)
                {
                    Nodo n1 = PadreNodoY(nodo1.dato);
                    Nodo n2 = PadreNodoY(nodo2.dato);
                    Console.Clear();
                    Intercambio(raiz, n1, n2, nodo1, nodo2);

                }
                else
                {
                    Console.WriteLine("ALGUNO DE LOS ELEMENTOS NO EXISTE EN EL ÁRBOL");
                }
            }
        }

        public void CambiarLugarMetComp(Nodo raiz, Nodo nodo1, Nodo nodo2)
        {
            try
            {
                if (raiz.dato == nodo1.dato || raiz.dato == nodo2.dato)
                {
                    componenteSubArbol++;
                }
                if (raiz != null)
                {
                    CambiarLugarMetComp(raiz.izquierda, nodo1, nodo2);
                    CambiarLugarMetComp(raiz.derecha, nodo1, nodo2);
                }
            }
            catch (NullReferenceException)
            {
                System.Console.WriteLine("Error null");
            }
        }

        public void BusquedaDosNodos(Nodo nodo, Nodo nodo1, Nodo nodo2)
        {
            try
            {
                if (nodo.dato == nodo1.dato || nodo.dato == nodo2.dato)
                {
                    if (nodo.dato == nodo1.dato)
                    {
                        nodoHijoUno = nodo;
                    }
                    if (nodo.dato == nodo2.dato)
                    {
                        nodoHijoDos = nodo;
                    }
                    componenteSubArbol++;
                }
                if (nodo != null)
                {
                    BusquedaDosNodos(nodo.izquierda, nodo1, nodo2);
                    BusquedaDosNodos(nodo.derecha, nodo1, nodo2);
                }
            }
            catch (NullReferenceException)
            {
                System.Console.WriteLine("Error null");
            }
        }

        public void Intercambio(Nodo raiz, Nodo n1, Nodo n2, Nodo nodo1, Nodo nodo2)
        {
            try
            {
                if (n1.izquierda.dato == nodo1.dato)
                {
                    n1.izquierda = nodo2;
                }
                else if (n1.derecha.dato == nodo1.dato)
                {
                    n1.derecha = nodo2;
                }

                if (n2.derecha.dato == nodo2.dato)
                {
                    n2.derecha = nodo1;
                }
                else if (n2.izquierda.dato == nodo2.dato)
                {
                    n2.izquierda = nodo1;
                }
            }
            catch (NullReferenceException)
            {
                if (n1.derecha.dato == nodo1.dato)
                {
                    n1.derecha = nodo2;
                }
                if (n2.izquierda.dato == nodo2.dato)
                {
                    n2.izquierda = nodo1;
                }
            }
        }
    }
}
