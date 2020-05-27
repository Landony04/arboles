using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArboles
{
    class Program
    {
        static ArbolBinarioDos segundoArbol = new ArbolBinarioDos();
        static ArbolBinario arbol = new ArbolBinario();
        
        static int conteoNodos = 0;
        static int opcion = 0;
        static int dato;
        static int datoArbolDos = 0;
       
        static String arbolSeleccionado = "";

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("ÁRBOLES BINARIOS");
                Console.WriteLine("1. Insertar Nodo");
                Console.WriteLine("2. Descendientes de un Nodo X");
                Console.WriteLine("3. Padre de un Nodo X");
                Console.WriteLine("4. Nodos Interiores");
                Console.WriteLine("5. Nodos Hojas");
                Console.WriteLine("6. Grado de un Nodo X");
                Console.WriteLine("7. Nivel de un Nodo X");
                Console.WriteLine("8. Longitud de camino Interno");
                Console.WriteLine("9. Longitud de camino Externo");
                Console.WriteLine("10. Determinar si los arboles 'A' Y 'B' son similares");
                Console.WriteLine("11. Determinar si los arboles 'A' Y 'B' son equivalentes");
                Console.WriteLine("12. Eliminar todos los nodos hojas del arbol");
                Console.WriteLine("13. Intercambiar posicion entre dos Nodos");
                Console.WriteLine("14. SALIR");
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Dato inválido");
                    Console.ReadKey();
                    Console.Clear();
                }

                switch(opcion)
                {
                    case 1:
                        insertarNodo();
                        break;
                    case 2:
                        descendientesNodo();
                        break;
                    case 3:
                        padreDeNodo();
                        break;
                    case 4:
                        nodosInteriores();
                        break;
                    case 5:
                        nodosHojas();
                        break;
                    case 6:
                        gradoDeNodo();
                        break;
                    case 7:
                        nivelDeNodo();
                        break;
                    case 8:
                        longitudCaminoInterno();
                        break;
                    case 9:
                        longitudCaminoExterno();
                        break;
                    case 10:
                        arbolesSimilares();
                        break;
                    case 11:
                        arbolesEquivalentes();
                        break;
                    case 12:
                        eliminarHojasArbol();
                        break;
                    case 13:
                        intercambioSubArboles();
                        break;

                }
            } while (opcion != 14);
        }


        //Metodo para insertar nodo en arbol A o B
        public static void insertarNodo()
        {
            Console.Clear();
            Console.WriteLine("INGRESE EL ÁRBOL (A o B) AL QUE DESEA INGRESAR EL NUEVO NODO ");
            try
            {
                arbolSeleccionado = Console.ReadLine();
                Console.Clear();
            }
            catch (FormatException)
            {
                Console.WriteLine("DATO INVÁLIDO");
                Console.ReadKey();
                Console.Clear();
            }
            if (arbolSeleccionado == "A")
            {
                dato = 0;
                Console.WriteLine("INGRESE UN DATO PARA EL NUEVO NODO: ");
                try
                {
                    dato = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVÁLIDO");
                }
                if (arbol.BusquedaComprobacion(dato) == false)
                {
                    arbol.Insercion(dato);
                }
                else if (arbol.BusquedaComprobacion(dato) == true)
                {
                    Console.WriteLine("CAMPO LLAVE YA EN USO");
                }
            }
            else if (arbolSeleccionado == "B")
            {
                datoArbolDos = 0;

                Console.WriteLine("INGRESE UN DATO PARA EL NUEVO NODO: ");
                try
                {
                    datoArbolDos = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("DATO INVÁLIDO");
                }
                if (segundoArbol.BusquedaComprobacion(datoArbolDos) == false)
                {
                    segundoArbol.Insercion(datoArbolDos);
                }
                else if (segundoArbol.BusquedaComprobacion(datoArbolDos) == true)
                {
                    Console.WriteLine("CAMPO LLAVE YA EN USO");
                }
            }
            else
            {
                Console.WriteLine("ÁRBOL INVÁLIDO");
            }
            Console.ReadKey();
        }

        //Metodo para buscar descendiente de Nodo
        public static void descendientesNodo()
        {
            Console.Clear();
            arbolSeleccionado = "";
            Console.WriteLine("SELECCIONE EL ÁRBOL A RECORRER (A o B)");
            try
            {
                arbolSeleccionado = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("DATO INVÁLIDO");
            }
            if (arbolSeleccionado == "A")
            {
                if (!arbol.esRaizVacia())
                {
                    int buscar = 0;
                    Console.WriteLine("INGRESE EL NODO A BUSCAR: ");
                    try
                    {
                        buscar = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("DATO INVÁLIDO");
                    }
                    //Console.WriteLine("EL NODO NO EXISTE");
                    arbol.DescendientesNodoX(buscar);
                } else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            }
            else if (arbolSeleccionado == "B")
                if (!segundoArbol.esRaizVacia())
                {
                    int buscar = 0;
                    Console.WriteLine("INGRESE EL NODO A BUSCAR: ");
                    try
                    {
                        buscar = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("DATO INVÁLIDO");
                    }
                    Console.WriteLine("EL NODO NO EXISTE");
                    segundoArbol.DescendientesNodoX(buscar);
                }
                else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            else
            {
                Console.WriteLine("ÁRBOL INVÁLIDO");
            }

            Console.ReadKey();
        }

        //Metodo para buscar padre de nodoX
        public static void padreDeNodo()
        {
            Console.Clear();
            arbolSeleccionado = "";
            Console.WriteLine("SELECCIONE EL ÁRBOL A RECORRER (A o B)");
            try
            {
                arbolSeleccionado = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("DATO INVÁLIDO, INGRESE UN NÚMERO ENTERO");
            }
            if (arbolSeleccionado == "A")
            {
                if (!arbol.esRaizVacia())
                {
                    int buscar = 0;
                    Console.WriteLine("INGRESE EL NODO A BUSCAR: ");
                    try
                    {
                        buscar = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("DATO INVÁLIDO");
                    }
                    Console.WriteLine("EL NODO NO EXISTE");
                    arbol.PadreNodoY(buscar);
                }
                else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            }
            else if (arbolSeleccionado == "B")
            {
                if (!segundoArbol.esRaizVacia())
                {
                    int Buscar = 0;
                    Console.WriteLine("INGRESE EL NODO A BUSCAR: ");
                    try
                    {
                        Buscar = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("DATO INVÁLIDO");
                    }
                    Console.WriteLine("EL NODO NO EXISTE");
                    segundoArbol.PadreNodoY(Buscar);
                }
                else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            }
            else
            {
                Console.WriteLine("ÁRBOL INVÁLIDO");
            }

            Console.ReadKey();
        }

        //Metodo para mostrar nodos interiores del arbol
        private static void nodosInteriores()
        {
            Console.Clear();
            arbolSeleccionado = "";
            Console.WriteLine("SELECCIONE EL ÁRBOL A RECORRER (A o B)");
            try
            {
                arbolSeleccionado = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("DATO INVÁLIDO");
            }
            if (arbolSeleccionado == "A")
            {
                if (!arbol.esRaizVacia())
                {
                    Console.WriteLine("LOS NODOS INTERIORES DEL ÁRBOL SON :");
                    arbol.NodosInteriores();
                }
                else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            }
            else if (arbolSeleccionado == "B")
            {
                if (!segundoArbol.esRaizVacia())
                {
                    Console.WriteLine("LOS NODOS INTERIORES DEL ÁRBOL SON :");
                    segundoArbol.NodosInteriores();
                }
                else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            }
            else
            {
                Console.WriteLine("ÁRBOL INVÁLIDO");
            }
            Console.ReadKey();
        }

        //Metodo para mostrar los nodos hojas del arbol
        private static void nodosHojas()
        {
            Console.Clear();
            arbolSeleccionado = "";
            Console.WriteLine("SELECCIONE EL ÁRBOL A RECORRER (A o B)");
            try
            {
                arbolSeleccionado = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("DATO INVÁLIDO");
            }
            if (arbolSeleccionado == "A") { 
                    if (!arbol.esRaizVacia())
                    {
                        Console.WriteLine("LOS NODOS HOJA DEL ÁRBOL SON:");
                        arbol.NodosHoja();
                    }
                    else
                    {
                        Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                    }
            } else if(arbolSeleccionado == "B")
            {
                if (!segundoArbol.esRaizVacia())
                {
                    Console.WriteLine("LOS NODOS HOJA DEL ÁRBOL SON:");
                    segundoArbol.NodosHoja();
                }
                else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else { 
                    Console.WriteLine("ÁRBOL INVÁLIDO");
            }
            Console.ReadKey();
        }

        //Metodo para mostrar el grado de un nodo
        private static void gradoDeNodo()
        {
            Console.Clear();
            arbolSeleccionado = "";
            Console.WriteLine("SELECCIONE EL ÁRBOL A RECORRER (A o B)");
            try
            {
                arbolSeleccionado = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("DATO INVÁLIDO");
            }
            if (arbolSeleccionado == "A")
            {
                if (!arbol.esRaizVacia())
                {
                    int Nodo = 0;
                    Console.WriteLine("INGRESE EL NODO A CONOCER SU GRADO: ");
                    try
                    {
                        Nodo = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("DATO INVÁLIDO");
                    }
                    Console.WriteLine("EL NODO NO EXISTE");
                    arbol.GradoNodoX(Nodo);
                }
                else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else if (arbolSeleccionado == "B")
            {
                if (!segundoArbol.esRaizVacia())
                {
                    int buscar = 0;
                    Console.WriteLine("INGRESE EL NODO A CONOCER SU GRADO: ");
                    try
                    {
                        buscar = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("DATO INVÁLIDO, INGRESE UN NÚMERO ENTERO");
                    }
                    Console.WriteLine("EL NODO NO EXISTE");
                    segundoArbol.GradoNodoX(buscar);
                }
                else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else
            {
                Console.WriteLine("ÁRBOL INVÁLIDO");
            }
            Console.ReadKey();
        }

        //Metodo para mostrar el nivel del nodo
        private static void nivelDeNodo()
        {
            Console.Clear();
            arbolSeleccionado = "";
            Console.WriteLine("SELECCIONE EL ÁRBOL A RECORRER (A o B)");
            try
            {
                arbolSeleccionado = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("DATO INVÁLIDO");
            }
            if (arbolSeleccionado == "A")
            {
                if (!arbol.esRaizVacia())
                {
                    int nodo = 0;
                    Console.WriteLine("INGRESE EL NODO A CONOCER SU NIVEL: ");
                    try
                    {
                        nodo = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("DATO INVÁLIDO");
                    }
                    Console.WriteLine("EL NODO NO EXISTE");
                    arbol.NivelNodoX(nodo);
                }
                else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else if (arbolSeleccionado == "B")
            {
                if (!segundoArbol.esRaizVacia())
                {
                    int nodo = 0;
                    Console.WriteLine("INGRESE EL NODO A CONOCER SU NIVEL: ");
                    try
                    {
                        nodo = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("DATO INVÁLIDO");
                    }
                    Console.WriteLine("EL NODO NO EXISTE");
                    segundoArbol.NivelNodoX(nodo);
                } else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else
            {
                Console.WriteLine("ÁRBOL INVÁLIDO");
            }
            Console.ReadKey();
        }

        //Metodo para mostrar la longitud del camino interno de un arbol
        private static void longitudCaminoInterno()
        {
            Console.Clear();
            arbolSeleccionado = "";
            Console.WriteLine("SELECCIONE EL ÁRBOL A RECORRER (A o B)");
            try
            {
                arbolSeleccionado = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("DATO INVÁLIDO");
            }
            if (arbolSeleccionado == "A")
            {
                if (!arbol.esRaizVacia())
                {
                    arbol.CaminoInterno();
                } else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else if (arbolSeleccionado == "B")
            {
                if (segundoArbol.esRaizVacia())
                {
                    segundoArbol.CaminoInterno();
                } else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else
            {
                Console.WriteLine("ÁRBOL INVÁLIDO");
            }
            Console.ReadKey();
        }

        //Metodo para mostrar la longitud del camino externo
        private static void longitudCaminoExterno()
        {
            Console.Clear();
            arbolSeleccionado = "";
            Console.WriteLine("SELECCIONE EL ÁRBOL A RECORRER (A o B)");
            try
            {
                arbolSeleccionado = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("DATO INVÁLIDO");
            }
            if (arbolSeleccionado == "A")
            {
                if (!arbol.esRaizVacia())
                {
                    arbol.CaminoExterno();
                } else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else if (arbolSeleccionado == "B")
            {
                if (!segundoArbol.esRaizVacia())
                {
                    segundoArbol.CaminoExterno();
                } else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else
            {
                Console.WriteLine("ÁRBOL INVÁLIDO");
            }
            Console.ReadKey();
        }

        //Metodo para determinar si 2 arboles binarios son similares
        private static void arbolesSimilares()
        {
            Console.Clear();
            conteoNodos = 0;
            if (!arbol.esRaizVacia() && !segundoArbol.esRaizVacia())
            {
                ArbolesSimilares(arbol.ObtenerRaiz(), segundoArbol.ObtenerRaiz());
                if (conteoNodos == arbol.nodos && conteoNodos == segundoArbol.nodos)
                {
                    Console.WriteLine("LOS ÁRBOLES 'A' Y 'B' SON SIMILARES");
                } else
                {
                    Console.WriteLine("LOS ÁRBOLES 'A' Y 'B' NO SON SIMILARES");
                }
            } else
            {
                Console.WriteLine("NO SE PUEDE REALIZAR LA OPERACIÓN PORQUE LOS DOS ÁRBOLES DEBEN TENER AL MENOS UN NODO");
            }
            Console.ReadKey();
        }

        public static void ArbolesSimilares(Nodo nodo, Nodo nodo2)
        {
            if (nodo != null && nodo2 != null)
            {
                conteoNodos++;
                ArbolesSimilares(nodo.izquierda, nodo2.izquierda);
                ArbolesSimilares(nodo.derecha, nodo2.derecha);
            }
        }

        //Metodo para determinar si 2 arboles binarios son equivalentes
        private static void arbolesEquivalentes()
        {
            Console.Clear();
            conteoNodos = 0;
            if (!arbol.esRaizVacia() && !segundoArbol.esRaizVacia())
            {
                ArbolesEquivalentes(arbol.ObtenerRaiz(), segundoArbol.ObtenerRaiz());
                if (conteoNodos == arbol.nodos && conteoNodos == segundoArbol.nodos)
                {
                    Console.WriteLine("LOS ÁRBOLES 'A' Y 'B' SON EQUIVALENTES");
                } else
                {
                    Console.WriteLine("LOS ÁRBOLES 'A' Y 'B' NO SON EQUIVALENTES");
                }
            } else
            {
                Console.WriteLine("NO SE PUEDE REALIZAR LA OPERACIÓN PORQUE LOS DOS ÁRBOLES DEBEN TENER AL MENOS UN NODO");
            }
            Console.ReadKey();
        }

        public static void ArbolesEquivalentes(Nodo nodo, Nodo nodo2)
        {
            if ((nodo != null && nodo2 != null) && nodo.dato == nodo2.dato)
            {
                conteoNodos++;
                ArbolesEquivalentes(nodo.izquierda, nodo2.izquierda);
                ArbolesEquivalentes(nodo.derecha, nodo2.derecha);
            }
        }

        //Metodo para eliminar todas las hojas de un arbol binario
        private static void eliminarHojasArbol()
        {
            Console.Clear();
            arbolSeleccionado = "";
            Console.WriteLine("SELECCIONE EL ÁRBOL A RECORRER (A o B)");
            try
            {
                arbolSeleccionado = Console.ReadLine();
            } catch (FormatException)
            {
                Console.WriteLine("DATO INVÁLIDO");
            }

            if (arbolSeleccionado == "A")
            {
                if (!arbol.esRaizVacia())
                {
                    arbol.EliminarNodosHoja();
                    Console.Clear();
                    Console.WriteLine("\n NODOS HOJA ELIMINADOS");
                } else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else if (arbolSeleccionado == "B")
            {
                if (!segundoArbol.esRaizVacia())
                {
                    segundoArbol.EliminarNodosHoja();
                    Console.Clear();
                    Console.WriteLine("\n NODOS HOJA ELIMINADOS");
                } else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else
            {
                Console.WriteLine("ÁRBOL INVÁLIDO");
            }
            Console.ReadKey();
        }

        //Metodo para intercambiar subArboles
        private static void intercambioSubArboles()
        {
            Console.Clear();
            arbolSeleccionado = "";
            Console.WriteLine("SELECCIONE EL ÁRBOL A ELIMINAR NODOS HOJA (A o B)");
            try
            {
                arbolSeleccionado = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("DATO INVÁLIDO");
            }
            if (arbolSeleccionado == "A")
            {
                if (!arbol.esRaizVacia())
                {
                    Console.WriteLine("ÁRBOL ACTUAL");
                    //arbol.RecorridoInOrden();
                    Console.WriteLine("\nINGRESE EL NODO DE LA RAMA IZQUIERDA QUE DESEA CAMBIAR A LA RAMA DERECHA: ");
                    Nodo nodo1 = new Nodo(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("INGRESE EL NODO DE LA RAMA DERECHA QUE DESEA CAMBIAR A LA RAMA IZQUIERDA: ");
                    Nodo nodo2 = new Nodo(Convert.ToInt32(Console.ReadLine()));
                    arbol.CambiarLugar(nodo1, nodo2);
                    Console.WriteLine("A CONTINUACIÓN SE LE PRESENTA EL ÁRBOL... PRESIONE ENTER");
                    Console.ReadKey();
                    //arbol.RecorridoInOrden();
                } else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else if (arbolSeleccionado == "B")
            {
                if (!segundoArbol.esRaizVacia())
                {
                    Console.WriteLine("ÁRBOL ACTUAL");
                    //Secundario.RecorridoInOrden();
                    Console.WriteLine("\nINGRESE EL NODO DE LA RAMA IZQUIERDA QUE DESEA CAMBIAR A LA RAMA DERECHA: ");
                    Nodo nodo1 = new Nodo(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("INGRESE EL NODO DE LA RAMA DERECHA QUE DESEA CAMBIAR A LA RAMA IZQUIERDA: ");
                    Nodo nodo2 = new Nodo(Convert.ToInt32(Console.ReadLine()));
                   // Secundario.CambiarLugar(nodo1, nodo2);
                    Console.WriteLine("A CONTINUACIÓN SE LE PRESENTA EL ÁRBOL... PRESIONE ENTER");
                    Console.ReadKey();
                    //Secundario.RecorridoInOrden();
                } else
                {
                    Console.WriteLine("EL ÁRBOL ESTÁ VACÍO");
                }
            } else
            {
                Console.WriteLine("ÁRBOL INVÁLIDO");
            }
            Console.ReadKey();
        }
    }
}
